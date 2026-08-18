using ATIEnvioSMS.LayerData.Models.DTOs.cod;
using ATIEnvioSMS.LayerData.Models.DTOs.sms;
using ATIEnvioSMS.LayerData.Models.DTOs.sys;
using ATIEnvioSMS.LayerData.Models.Entities.cod;
using ATIEnvioSMS.LayerData.Models.Entities.sms;
using ATIEnvioSMS.LayerData.Models.Entities.sys;
using AutoMapper;

namespace ATIEnvioSMS.LayerLogic.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            /*   //  CreateMap<SoftwareAutorizado, SoftwareAutorizadoViewModel>().ReverseMap();

               CreateMap<SoftwareAutorizado, SoftwareAutorizadoViewModel>()
                   .ForMember(
                   destino => destino.Name,
                   opt => opt.MapFrom(source => source.NombreSoftware)).ReverseMap();*/

            CreateMap<Empresa, BaseEmpresaDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>()
                  .ForMember(destino => destino.ListaContactos, opt => opt.MapFrom(source => source.Contactos))
                  .ReverseMap();
            CreateMap<Empresa, CreateOrUpdateEmpresaDTO>().ReverseMap();

          /*  CreateMap<EstadoSolicitud, EstadoSolicitudDTO>().ReverseMap();

            CreateMap<PlanesSm, BasePlanSMSDTO>().ReverseMap();
            CreateMap<PlanesSm, PlanSMSDTO>()
                  .ForMember(destino => destino.UsuarioAgrega, opt => opt.MapFrom(source => source.IdusuarioAgregaNavigation.Nombre))
                  .ForMember(destino => destino.UsuarioAct, opt => opt.MapFrom(source => source.IdusuarioActNavigation.Nombre))
                  .ReverseMap();
            CreateMap<PlanesSm, CrearPlanSMSDTO>().ReverseMap();
            CreateMap<PlanesSm, UpdatePlanSMSDTO>().ReverseMap();

            CreateMap<TipoSolicitud, TipoSolicitudDTO>().ReverseMap();*/
            
            CreateMap<Contacto, BaseContactoDTO>().ReverseMap();
            CreateMap<Contacto, ContactoSinEmpresaDTO>().ReverseMap();
            CreateMap<Contacto, ContactoDTO>()
                  .ForMember(destino => destino.Empresa, opt => opt.MapFrom(source => source.IdempresaNavigation.Nombre))
                  .ForMember(destino => destino.UsuarioAgrega, opt => opt.MapFrom(source => source.IdusuarioAgregaNavigation.Nombre))
                  .ForMember(destino => destino.UsuarioAct, opt => opt.MapFrom(source => source.IdusuarioActNavigation.Nombre))
                  .ReverseMap();
            CreateMap<Contacto, CreateContactoDTO>().ReverseMap();
            CreateMap<Contacto, UpdateContactoDTO>().ReverseMap();

            CreateMap<GrupoContactos, BaseGrupoContactoDTO>().ReverseMap();
            CreateMap<GrupoContactos, GrupoContactoDTO>()
                .ForMember(destino => destino.UsuarioPertenece, opt => opt.MapFrom(source => source.IdusuarioNavigation.Nombre))
                .ReverseMap();
            CreateMap<GrupoContactos, GrupoContactoConContactosDTO>()
                 .ForMember(destino => destino.UsuarioPertenece, opt => opt.MapFrom(source => source.IdusuarioNavigation.Nombre))
                .ReverseMap();
            CreateMap<GrupoContactos, CreateGrupoContactosDTO>().ReverseMap();
            CreateMap<GrupoContactos, UpdateGrupoContactosDTO>().ReverseMap();

         //   CreateMap<ContactosGrupoRelacion, ContactoGrupoRelacionDTO>().ReverseMap();
            
            CreateMap<RegSms, BaseRegSmsDTO>().ReverseMap();
            CreateMap<RegSms, RegSmsDTO>().ReverseMap();
            CreateMap<RegSms, CreateSmsDTO>().ReverseMap();

            CreateMap<RegSmsDetallesContacto, BaseRegSmsDetallesContactoDTO>().ReverseMap();
            CreateMap<RegSmsDetallesContacto, RegSmsDetallesContactoDTO>().ReverseMap();
            CreateMap<RegSmsDetallesContacto, CreateRegSmsDetallesContactoDTO>().ReverseMap();

            CreateMap<RegSmsDetallesContactosGrupo, BaseRegSmsDetallesContactosGrupoDTO>().ReverseMap();
            CreateMap<RegSmsDetallesContactosGrupo, RegSmsDetallesContactosGrupoDTO>().ReverseMap();
            CreateMap<RegSmsDetallesContactosGrupo, CreateRegSmsDetallesContactosGrupoDTO>().ReverseMap();

          /*  CreateMap<SolicitudPlanesSm, BaseSolicitudPlanesDTO>().ReverseMap();
            
            CreateMap<SolicitudPlanesSm, SolicitudPlanesDTO>()
                  .ForMember(destino => destino.Empresa, opt => opt.MapFrom(source => source.IdempresaNavigation.Nombre))                  
                  .ForMember(destino => destino.UsuarioAct, opt => opt.MapFrom(source => source.IdusuarioActNavigation.Nombre))
                  .ForMember(destino => destino.EstadoSolicitud, opt => opt.MapFrom(source => source.IdestadoSolicitudNavigation.EstadoSolicitud1))
                  .ForMember(destino => destino.TipoSolicitud, opt => opt.MapFrom(source => source.IdtipoSolicitudNavigation.TipoSolicitud1))
                  .ForMember(destino => destino.Plan, opt => opt.MapFrom(source => source.IdplanSmsNavigation.Plan))
                  .ReverseMap();
            CreateMap<SolicitudPlanesSm, CrearSolicitudPlanesDTO>().ReverseMap();
            CreateMap<SolicitudPlanesSm, ActualizarSolicitudPlanesDTO>().ReverseMap();   */


            CreateMap<Auditorium, BaseAuditoriumDTO>().ReverseMap();
            CreateMap<Auditorium, AuditoriumDTO>().ReverseMap();
            CreateMap<Auditorium, CreateAuditoriumDTO>().ReverseMap();

            CreateMap<Notificacione, NotificacionesDTO>().ReverseMap();



            CreateMap<Usuario, BaseUsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>()
                  .ForMember(destino => destino.Empresa, opt => opt.MapFrom(source => source.IdempresaNavigation.Nombre))
                  .ForMember(destino => destino.NombUsuario, opt => opt.MapFrom(source => source.Usuario1))
                  .ForMember(destino => destino.UsuarioAgrega, opt => opt.MapFrom(source => source.IdusuarioAgregaNavigation.Nombre))
                  .ForMember(destino => destino.UsuarioAct, opt => opt.MapFrom(source => source.IdusuarioActNavigation.Nombre))
                  .ForMember(destino => destino.ListaGruposDeContactos, opt => opt.MapFrom(source => source.GruposContactos))
                  .ReverseMap();                
            CreateMap<Usuario, CreateUsuarioDTO>()
                .ForMember(destino => destino.NombUsuario, opt => opt.MapFrom(source => source.Usuario1))
                .ReverseMap();
            CreateMap<Usuario, UpdateUsuarioDTO>()
                 .ForMember(destino => destino.NombUsuario, opt => opt.MapFrom(source => source.Usuario1))
                .ReverseMap();

        }
    }
}
