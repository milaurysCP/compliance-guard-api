using AutoMapper;
using ComplianceGuardPro.Data;
using ComplianceGuardPro.Modules.Clientes.DTOs;
using ComplianceGuardPro.Modules.Clientes.Models;
using ComplianceGuardPro.Modules.Direcciones.Models;
using ComplianceGuardPro.Modules.Contactos.Models;
using ComplianceGuardPro.Modules.Beneficiarios.Models;
using ComplianceGuardPro.Modules.Intermediarios.Models;
using ComplianceGuardPro.Modules.ActividadesEconomicas.Models;
using ComplianceGuardPro.Modules.PerfilesFinancieros.Models;
using ComplianceGuardPro.Modules.Operaciones.Models;
using ComplianceGuardPro.Modules.Pagos.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceGuardPro.Modules.Clientes.Services;

public class ClienteImpl : ICliente
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ClienteImpl(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ClienteSummaryDto>> obtenerClientes()
    {
        var clientes = await _context.Clientes
            .Select(c => _mapper.Map<ClienteSummaryDto>(c))
            .ToListAsync();

        return clientes;
    }

    public async Task crearClienteCompleto(ClienteDto dto)
    {
        if (dto.DatosBasicos == null)
        {
            throw new ArgumentException("DatosBasicos es requerido");
        }

        // Validar unicidad de DocumentoIdentidad
        if (!string.IsNullOrWhiteSpace(dto.DatosBasicos.DocumentoIdentidad))
        {
            var existeDocumento = await _context.Clientes
                .AnyAsync(c => c.DocumentoIdentidad == dto.DatosBasicos.DocumentoIdentidad);
            
            if (existeDocumento)
            {
                throw new InvalidOperationException($"Ya existe un cliente con el documento de identidad '{dto.DatosBasicos.DocumentoIdentidad}'");
            }
        }

        // Validar unicidad de RNC
        if (!string.IsNullOrWhiteSpace(dto.DatosBasicos.Rnc))
        {
            var existeRnc = await _context.Clientes
                .AnyAsync(c => c.Rnc == dto.DatosBasicos.Rnc);
            
            if (existeRnc)
            {
                throw new InvalidOperationException($"Ya existe un cliente con el RNC '{dto.DatosBasicos.Rnc}'");
            }
        }

        // Crear el cliente principal
        var cliente = new Cliente
        {
            Nombre = dto.DatosBasicos.Nombre,
            TipoPersona = dto.DatosBasicos.TipoPersona,
            Siglas = dto.DatosBasicos.Siglas,
            DocumentoIdentidad = dto.DatosBasicos.DocumentoIdentidad,
            FechaCreacion = dto.DatosBasicos.FechaCreacion,
            Rnc = dto.DatosBasicos.Rnc,
            RegistroMercantil = dto.DatosBasicos.RegistroMercantil,
            CasaMatriz = dto.DatosBasicos.CasaMatriz
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        // Crear dirección si existe
        if (dto.Direccion != null)
        {
            var esRepublicaDominicana = !string.IsNullOrWhiteSpace(dto.Direccion.Pais) && 
                                        dto.Direccion.Pais.Equals("República Dominicana", StringComparison.OrdinalIgnoreCase);

            if (esRepublicaDominicana)
            {
                // Si es República Dominicana, provincia y municipio son REQUERIDOS
                if (string.IsNullOrWhiteSpace(dto.Direccion.Provincia))
                {
                    throw new ArgumentException("La provincia es requerida para direcciones en República Dominicana.");
                }

                if (string.IsNullOrWhiteSpace(dto.Direccion.Municipio))
                {
                    throw new ArgumentException("El municipio es requerido para direcciones en República Dominicana.");
                }
            }
            else
            {
                // Si NO es República Dominicana, provincia y municipio NO deben enviarse
                if (!string.IsNullOrWhiteSpace(dto.Direccion.Provincia))
                {
                    throw new ArgumentException($"No se debe enviar provincia para direcciones fuera de República Dominicana (país: {dto.Direccion.Pais}).");
                }

                if (!string.IsNullOrWhiteSpace(dto.Direccion.Municipio))
                {
                    throw new ArgumentException($"No se debe enviar municipio para direcciones fuera de República Dominicana (país: {dto.Direccion.Pais}).");
                }
            }

            var direccion = new Direccion
            {
                ClienteId = cliente.Id,
                Calle = dto.Direccion.Calle,
                Numero = dto.Direccion.Numero,
                Sector = dto.Direccion.Sector,
                CodigoPostal = dto.Direccion.CodigoPostal,
                Pais = dto.Direccion.Pais,
                Provincia = dto.Direccion.Provincia,
                Municipio = dto.Direccion.Municipio
            };
            _context.Direcciones.Add(direccion);
        }

        // Crear contactos
        if (dto.Contactos != null && dto.Contactos.Any())
        {
            foreach (var c in dto.Contactos)
            {
                _context.Contactos.Add(new Contacto
                {
                    ClienteId = cliente.Id,
                    Tipo = c.TipoContacto,
                    Valor = c.ValorContacto
                });
            }
        }

        // Crear actividad económica
        if (dto.ActividadEconomica != null)
        {
            _context.ActividadesEconomicas.Add(new ActividadEconomica
            {
                ClienteId = cliente.Id,
                Sector = dto.ActividadEconomica.Sector,
                CampoLaboral = dto.ActividadEconomica.CampoLaboral,
                OrigenFondos = dto.ActividadEconomica.OrigenFondos
            });
        }

        // Crear SO Financiero (Beneficiarios)
        if (dto.SOFinanciero != null && dto.SOFinanciero.Any())
        {
            foreach (var so in dto.SOFinanciero)
            {
                _context.BeneficiariosFinales.Add(new BeneficiarioFinal
                {
                    ClienteId = cliente.Id,
                    Tipo = so.TipoSOFinanciero,
                    Nombre = so.NombreSOFinanciero,
                    Apellidos = so.ApellidosSOFinanciero,
                    Identificacion = so.IdentificacionSOFinanciero,
                    Nacionalidad = so.NacionalidadSOFinanciero
                });
            }
        }

        // Crear perfiles financieros
        if (dto.PerfilFinanciero != null && dto.PerfilFinanciero.Any())
        {
            foreach (var pf in dto.PerfilFinanciero)
            {
                _context.PerfilesFinancieros.Add(new PerfilFinanciero
                {
                    ClienteId = cliente.Id,
                    Ningreso = pf.Ningreso,
                    Fuentes = pf.Fuentes
                });
            }
        }

        // Crear operación
        if (dto.Operaciones != null)
        {
            var operacion = new Operacion
            {
                ClienteId = cliente.Id,
                TipoOperacion = dto.Operaciones.TipoOperacion,
                EndidadFinanciera = dto.Operaciones.EndidadFinanciera,
                CodigoOperacion = dto.Operaciones.CodigoOperacion,
                DescripcionOperacion = dto.Operaciones.DescripcionOperacion,
                PropositoOperacion = dto.Operaciones.PropositoOperacion,
                Monto = dto.Operaciones.Monto
            };
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            // Crear pago asociado a la operación
            if (dto.Pagos != null)
            {
                _context.Pagos.Add(new Pago
                {
                    OperacionId = operacion.Id,
                    Moneda = dto.Pagos.Moneda,
                    TipoPago = dto.Pagos.TipoPago,
                    CodigoPago = dto.Pagos.CodigoPago,
                    Monto = dto.Pagos.Monto
                });
            }
        }

        // Crear PEP
        if (dto.Peps != null)
        {
            _context.PersonasExpuestasPoliticamente.Add(new ComplianceGuardPro.Modules.PersonaExpuestaPoliticamente.Models.PersonaExpuestaPoliticamente
            {
                ClienteId = cliente.Id,
                CargoPeps = dto.Peps.CargoPeps,
                TipoPeps = dto.Peps.TipoPeps,
                NombrePeps = dto.Peps.NombrePeps,
                Decreto = dto.Peps.Decreto,
                InstitucionPeps = dto.Peps.InstitucionPeps
            });
        }

        // Crear responsable
        if (dto.Responsable != null)
        {
            _context.Responsables.Add(new ComplianceGuardPro.Modules.Responsable.Models.Responsable
            {
                ClienteId = cliente.Id,
                ResponsableTransaccion = dto.Responsable.ResponsableTransaccion,
                NombresResposable = dto.Responsable.NombresResposable,
                ApellidosResponsable = dto.Responsable.ApellidosResponsable,
                DireccionResponsable = dto.Responsable.DireccionResponsable,
                IdentificacionResponsable = dto.Responsable.IdentificacionResponsable,
                Correo = dto.Responsable.Correo,
                Telefono = dto.Responsable.Telefono,
                Cargo = dto.Responsable.Cargo
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> actualizarClienteCompleto(long id, ClienteDto dto)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return false;
        }

        if (dto.DatosBasicos != null)
        {
            // Validar unicidad de DocumentoIdentidad si cambió
            if (!string.IsNullOrWhiteSpace(dto.DatosBasicos.DocumentoIdentidad) && 
                dto.DatosBasicos.DocumentoIdentidad != cliente.DocumentoIdentidad)
            {
                var existeDocumento = await _context.Clientes
                    .AnyAsync(c => c.Id != id && c.DocumentoIdentidad == dto.DatosBasicos.DocumentoIdentidad);
                
                if (existeDocumento)
                {
                    throw new InvalidOperationException($"Ya existe otro cliente con el documento de identidad '{dto.DatosBasicos.DocumentoIdentidad}'");
                }
            }

            // Validar unicidad de RNC si cambió
            if (!string.IsNullOrWhiteSpace(dto.DatosBasicos.Rnc) && 
                dto.DatosBasicos.Rnc != cliente.Rnc)
            {
                var existeRnc = await _context.Clientes
                    .AnyAsync(c => c.Id != id && c.Rnc == dto.DatosBasicos.Rnc);
                
                if (existeRnc)
                {
                    throw new InvalidOperationException($"Ya existe otro cliente con el RNC '{dto.DatosBasicos.Rnc}'");
                }
            }

            // Actualizar datos básicos
            cliente.Nombre = dto.DatosBasicos.Nombre;
            cliente.TipoPersona = dto.DatosBasicos.TipoPersona;
            cliente.Siglas = dto.DatosBasicos.Siglas;
            cliente.DocumentoIdentidad = dto.DatosBasicos.DocumentoIdentidad;
            cliente.FechaCreacion = dto.DatosBasicos.FechaCreacion;
            cliente.Rnc = dto.DatosBasicos.Rnc;
            cliente.RegistroMercantil = dto.DatosBasicos.RegistroMercantil;
            cliente.CasaMatriz = dto.DatosBasicos.CasaMatriz;
        }

        // Actualizar dirección
        if (dto.Direccion != null)
        {
            var esRepublicaDominicana = !string.IsNullOrWhiteSpace(dto.Direccion.Pais) && 
                                        dto.Direccion.Pais.Equals("República Dominicana", StringComparison.OrdinalIgnoreCase);

            if (esRepublicaDominicana)
            {
                if (string.IsNullOrWhiteSpace(dto.Direccion.Provincia))
                {
                    throw new ArgumentException("La provincia es requerida para direcciones en República Dominicana.");
                }

                if (string.IsNullOrWhiteSpace(dto.Direccion.Municipio))
                {
                    throw new ArgumentException("El municipio es requerido para direcciones en República Dominicana.");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(dto.Direccion.Provincia))
                {
                    throw new ArgumentException($"No se debe enviar provincia para direcciones fuera de República Dominicana (país: {dto.Direccion.Pais}).");
                }

                if (!string.IsNullOrWhiteSpace(dto.Direccion.Municipio))
                {
                    throw new ArgumentException($"No se debe enviar municipio para direcciones fuera de República Dominicana (país: {dto.Direccion.Pais}).");
                }
            }

            var direccion = await _context.Direcciones.FirstOrDefaultAsync(d => d.ClienteId == id);
            if (direccion != null)
            {
                direccion.Calle = dto.Direccion.Calle;
                direccion.Numero = dto.Direccion.Numero;
                direccion.Sector = dto.Direccion.Sector;
                direccion.CodigoPostal = dto.Direccion.CodigoPostal;
                direccion.Pais = dto.Direccion.Pais;
                direccion.Provincia = dto.Direccion.Provincia;
                direccion.Municipio = dto.Direccion.Municipio;
            }
            else
            {
                _context.Direcciones.Add(new Direccion
                {
                    ClienteId = id,
                    Calle = dto.Direccion.Calle,
                    Numero = dto.Direccion.Numero,
                    Sector = dto.Direccion.Sector,
                    CodigoPostal = dto.Direccion.CodigoPostal,
                    Pais = dto.Direccion.Pais,
                    Provincia = dto.Direccion.Provincia,
                    Municipio = dto.Direccion.Municipio
                });
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> eliminarCliente(long id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Direcciones)
            .Include(c => c.Contactos)
            .Include(c => c.BeneficiariosFinales)
            .Include(c => c.ActividadesEconomicas)
            .Include(c => c.PerfilesFinancieros)
            .Include(c => c.Operaciones)
            .Include(c => c.Transacciones)
            .Include(c => c.PersonasExpuestasPoliticamente)
            .Include(c => c.Responsables)
            .Include(c => c.Referencias)
            .Include(c => c.Intermediarios)
            .Include(c => c.Evaluaciones)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
        {
            return false;
        }

        // Eliminación en cascada manual
        _context.Direcciones.RemoveRange(cliente.Direcciones);
        _context.Contactos.RemoveRange(cliente.Contactos);
        _context.BeneficiariosFinales.RemoveRange(cliente.BeneficiariosFinales);
        _context.ActividadesEconomicas.RemoveRange(cliente.ActividadesEconomicas);
        _context.PerfilesFinancieros.RemoveRange(cliente.PerfilesFinancieros);
        _context.Operaciones.RemoveRange(cliente.Operaciones);
        _context.Transacciones.RemoveRange(cliente.Transacciones);
        _context.PersonasExpuestasPoliticamente.RemoveRange(cliente.PersonasExpuestasPoliticamente);
        _context.Responsables.RemoveRange(cliente.Responsables);
        _context.Referencias.RemoveRange(cliente.Referencias);
        _context.Intermediarios.RemoveRange(cliente.Intermediarios);
        _context.Evaluaciones.RemoveRange(cliente.Evaluaciones);

        // Finalmente eliminar el cliente
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<ClienteSummaryDto>> buscarCliente(string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
        {
            return new List<ClienteSummaryDto>();
        }

        var filtroLower = filtro.ToLower().Trim();

        var clientes = await _context.Clientes
            .Where(c => 
                (c.DocumentoIdentidad != null && c.DocumentoIdentidad.ToLower().Contains(filtroLower)) ||
                (c.Nombre != null && c.Nombre.ToLower().Contains(filtroLower)) ||
                (c.Rnc != null && c.Rnc.ToLower().Contains(filtroLower))
            )
            .Select(c => _mapper.Map<ClienteSummaryDto>(c))
            .ToListAsync();

        return clientes;
    }

    public async Task<ClienteDto?> obtenerClienteCompleto(long id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Direcciones)
            .Include(c => c.Contactos)
            .Include(c => c.ActividadesEconomicas)
            .Include(c => c.BeneficiariosFinales)
            .Include(c => c.PerfilesFinancieros)
            .Include(c => c.Operaciones)
                .ThenInclude(o => o.Pagos)
            .Include(c => c.PersonasExpuestasPoliticamente)
            .Include(c => c.Responsables)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
        {
            return null;
        }

        return MapearClienteCompleto(cliente);
    }

    public async Task<List<ClienteDto>> buscarClienteCompleto(string filtro)
    {
        if (string.IsNullOrWhiteSpace(filtro))
        {
            return new List<ClienteDto>();
        }

        var filtroLower = filtro.ToLower().Trim();

        var clientes = await _context.Clientes
            .Include(c => c.Direcciones)
            .Include(c => c.Contactos)
            .Include(c => c.ActividadesEconomicas)
            .Include(c => c.BeneficiariosFinales)
            .Include(c => c.PerfilesFinancieros)
            .Include(c => c.Operaciones)
                .ThenInclude(o => o.Pagos)
            .Include(c => c.PersonasExpuestasPoliticamente)
            .Include(c => c.Responsables)
            .Where(c => 
                (c.DocumentoIdentidad != null && c.DocumentoIdentidad.ToLower().Contains(filtroLower)) ||
                (c.Nombre != null && c.Nombre.ToLower().Contains(filtroLower)) ||
                (c.Rnc != null && c.Rnc.ToLower().Contains(filtroLower))
            )
            .ToListAsync();

        return clientes.Select(c => MapearClienteCompleto(c)).ToList();
    }

    private ClienteDto MapearClienteCompleto(Cliente cliente)
    {
        var dto = new ClienteDto
        {
            DatosBasicos = new DatosBasicosDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                TipoPersona = cliente.TipoPersona,
                Siglas = cliente.Siglas,
                DocumentoIdentidad = cliente.DocumentoIdentidad,
                FechaCreacion = cliente.FechaCreacion,
                Rnc = cliente.Rnc,
                RegistroMercantil = cliente.RegistroMercantil,
                CasaMatriz = cliente.CasaMatriz
            }
        };

        // Dirección (primera si existe)
        var direccion = cliente.Direcciones.FirstOrDefault();
        if (direccion != null)
        {
            dto.Direccion = new DireccionDto
            {
                Id = direccion.Id,
                Calle = direccion.Calle,
                Numero = direccion.Numero,
                Sector = direccion.Sector,
                CodigoPostal = direccion.CodigoPostal,
                Pais = direccion.Pais,
                Provincia = direccion.Provincia,
                Municipio = direccion.Municipio
            };
        }

        // Contactos
        dto.Contactos = cliente.Contactos.Select(c => new ContactoDto
        {
            Id = c.Id,
            TipoContacto = c.Tipo,
            ValorContacto = c.Valor
        }).ToList();

        // Actividad Económica (primera si existe)
        var actividad = cliente.ActividadesEconomicas.FirstOrDefault();
        if (actividad != null)
        {
            dto.ActividadEconomica = new ActividadEconomicaDto
            {
                Id = actividad.Id,
                Sector = actividad.Sector,
                CampoLaboral = actividad.CampoLaboral,
                OrigenFondos = actividad.OrigenFondos
            };
        }

        // SO Financiero (Beneficiarios)
        dto.SOFinanciero = cliente.BeneficiariosFinales.Select(b => new SOFinancieroDto
        {
            Id = b.Id,
            TipoSOFinanciero = b.Tipo,
            NombreSOFinanciero = b.Nombre,
            ApellidosSOFinanciero = b.Apellidos,
            IdentificacionSOFinanciero = b.Identificacion,
            NacionalidadSOFinanciero = b.Nacionalidad
        }).ToList();

        // Perfil Financiero
        dto.PerfilFinanciero = cliente.PerfilesFinancieros.Select(p => new PerfilFinancieroDto
        {
            Id = p.Id,
            Ningreso = p.Ningreso,
            Fuentes = p.Fuentes
        }).ToList();

        // Operaciones (primera si existe)
        var operacion = cliente.Operaciones.FirstOrDefault();
        if (operacion != null)
        {
            dto.Operaciones = new OperacionesDto
            {
                Id = operacion.Id,
                TipoOperacion = operacion.TipoOperacion,
                EndidadFinanciera = operacion.EndidadFinanciera,
                CodigoOperacion = operacion.CodigoOperacion,
                DescripcionOperacion = operacion.DescripcionOperacion,
                PropositoOperacion = operacion.PropositoOperacion,
                Monto = operacion.Monto
            };

            // Pagos (primer pago de la operación si existe)
            var pago = operacion.Pagos.FirstOrDefault();
            if (pago != null)
            {
                dto.Pagos = new PagosDto
                {
                    Id = pago.Id,
                    Moneda = pago.Moneda,
                    TipoPago = pago.TipoPago,
                    CodigoPago = pago.CodigoPago,
                    Monto = pago.Monto
                };
            }
        }

        // PEPs (primera si existe)
        var pep = cliente.PersonasExpuestasPoliticamente.FirstOrDefault();
        if (pep != null)
        {
            dto.Peps = new PepsDto
            {
                Id = pep.Id,
                CargoPeps = pep.CargoPeps,
                TipoPeps = pep.TipoPeps,
                NombrePeps = pep.NombrePeps,
                Decreto = pep.Decreto,
                InstitucionPeps = pep.InstitucionPeps
            };
        }

        // Responsable (primero si existe)
        var responsable = cliente.Responsables.FirstOrDefault();
        if (responsable != null)
        {
            dto.Responsable = new ResponsableDto
            {
                Id = responsable.Id,
                ResponsableTransaccion = responsable.ResponsableTransaccion,
                NombresResposable = responsable.NombresResposable,
                ApellidosResponsable = responsable.ApellidosResponsable,
                DireccionResponsable = responsable.DireccionResponsable,
                IdentificacionResponsable = responsable.IdentificacionResponsable,
                Correo = responsable.Correo,
                Telefono = responsable.Telefono,
                Cargo = responsable.Cargo
            };
        }

        return dto;
    }
}