using System;
using System.Collections.Generic;
using System.Text;
using AppEvaTec.Models.Personas;
using System.Threading.Tasks;
namespace AppEvaTec.Interfaces.Personas
{
    public interface IFicSrvCatPersonas
    {
        Task<IList<cat_personas>> FicMetGetListCatPersonas();
        Task FicMetInsertNewCatPersonas(cat_personas FicPazt_cat_personas_Item);
        Task FicMetRemoveCatPersonas(cat_personas FicPaZt_cat_personas_Item);
        Task<IList<cat_personas>> FicSearchCatPersonas(String search);

        Task FicMetInsertNewCatUsuarios(cat_usuarios FicPaZt_cat_usuarios_Item);
        Task<IList<cat_usuarios>> FicMetGetListCatUsuarios();
        Task<IList<cat_usuarios>> FicMetGetListCatUsuarios(string usuario, string contraseña);

        Task<cat_usuarios> FitMetGetUsuario(string usuario, string contrasena);
        Task<IList<cat_institutos>> FicMetGetListInstitutos();
        Task<cat_institutos> FitMetGetInstituto(cat_personas FicPazt_cat_personas_Item);
        Task<cat_personas> FitMetGetPersona(rh_cat_telefonos FicPazt_rh_cat_telefonos_Item);
        Task<cat_personas> FitMetGetPersona(rh_cat_dir_web FicPazt_rh_cat_dir_web_Item);
        Task<cat_personas> FitMetGetPersona(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item);
        Task<cat_personas> FitMetGetPersona(cat_usuarios usuario);
        Task<cat_usuarios> FitMetGetUsuario(string correo);

        Task<IList<rh_cat_dir_web>> FicMetGetListRhCatDirWeb(int idPersona);
        Task FicMetInsertNewRhCatDirWeb(rh_cat_dir_web FicPazt_rh_cat_dir_web_Item);
        Task FicMetRemoveRhCatDirWeb(rh_cat_dir_web FicPaZt_rh_cat_dir_web_Item);
        Task<IList<rh_cat_dir_web>> FicSearchRhCatDirWeb(String search);

        Task<IList<rh_cat_domicilios>> FicMetGetListRhCatDomicilios(int idPersona);
        Task FicMetInsertNewRhCatDomicilios(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item);
        Task FicMetRemoveRhCatDomicilios(rh_cat_domicilios FicPaZt_rh_cat_domicilios_Item);
        Task<IList<rh_cat_domicilios>> FicSearchRhCatDomicilios(String search);

        Task<IList<rh_cat_telefonos>> FicMetGetListRhCatTelefonos(int idPersona);
        Task FicMetInsertNewRhCatTelefonos(rh_cat_telefonos FicPazt_rh_cat_telefonos_Item);
        Task FicMetRemoveRhCatTelefonos(rh_cat_telefonos FicPaZt_rh_cat_telefonos_Item);
        Task<IList<rh_cat_telefonos>> FicSearchRhCatTelefonos(String search);
    }
}
