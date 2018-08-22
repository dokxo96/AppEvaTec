using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppEvaTec.Helpers;
using AppEvaTec.Interfaces.Personas;
using AppEvaTec.Interfaces.SQLite;
using AppEvaTec.Models.Personas;
using SQLite;
using System.Threading.Tasks;
using AppEvaTec.Views;

namespace AppEvaTec.Services.Personas
{
    public class FicSrvCatPersonasList : IFicSrvCatPersonas
    {
        private static readonly FicAsyncLock ficMutex = new FicAsyncLock();
        private SQLiteAsyncConnection ficSQLiteConnection;

        //FIC: Constructor
        public FicSrvCatPersonasList()
        {
            var ficDataBasePath = DependencyService.Get<IFicConfigSQLiteNETStd>().FicGetDatabasePath();
            //var ficDataBasePath = "Data Source" = " + Server.MapPath(~/data/dbSQLite/";
            //SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=" + Server.MapPath("~/db/test_database2.db") + ";Version=3;New=True;Compress=True;");
            ficSQLiteConnection = new SQLiteAsyncConnection(ficDataBasePath);
            //FIC: Se manda llamar funcion local para verificar
            //si no existen las tablas crearlas de forma local en el dispositivo
            FicLoMetCreateDataBaseAsync();
        }

        //FIC: Metodo para crear las tablas si no existen localmente en el dispositivo
        public async void FicLoMetCreateDataBaseAsync()
        {

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                await ficSQLiteConnection.CreateTableAsync<cat_personas>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_dir_web>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_domicilios>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<rh_cat_telefonos>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<cat_institutos>(CreateFlags.None).ConfigureAwait(false);
                await ficSQLiteConnection.CreateTableAsync<cat_usuarios>(CreateFlags.None).ConfigureAwait(false);

            }
        }

        #region cat_personas

        public async Task<IList<cat_personas>> FicMetGetListCatPersonas()
        {
            var items = new List<cat_personas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<cat_personas>().ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task<cat_personas> FitMetGetPersona(cat_usuarios usuario)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_personas>()
                        .Where(x => x.IdPersona == usuario.IdUsuario)
                        .FirstOrDefaultAsync();

                return FicPersonaItem;

            }
        }

        public async Task<cat_personas> FitMetGetPersona(rh_cat_telefonos FicPazt_rh_cat_telefonos_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_personas>()
                        .Where(x => x.IdPersona == FicPazt_rh_cat_telefonos_Item.ClaveReferencia)
                        .FirstOrDefaultAsync();

                if (FicPersonaItem == null)
                {
                    return FicPersonaItem;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<cat_personas> FitMetGetPersona(rh_cat_dir_web FicPazt_rh_cat_dir_web_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_personas>()
                        .Where(x => x.IdPersona == FicPazt_rh_cat_dir_web_Item.ClaveReferencia)
                        .FirstOrDefaultAsync();

                if (FicPersonaItem == null)
                {
                    return FicPersonaItem;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<cat_personas> FitMetGetPersona(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_personas>()
                        .Where(x => x.IdPersona == FicPazt_rh_cat_domicilios_Item.ClaveReferencia)
                        .FirstOrDefaultAsync();

                if (FicPersonaItem == null)
                {
                    return FicPersonaItem;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task FicMetInsertNewCatUsuarios(cat_usuarios FicPazt_cat_usuarios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<cat_usuarios>()
                        .Where(x => x.Usuario == FicPazt_cat_usuarios_Item.Usuario &&
                        x.Contrasena == FicPazt_cat_usuarios_Item.Contrasena)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");

                cat_personas persona = new cat_personas();
                rh_cat_telefonos telefono = new rh_cat_telefonos();

                if (FicExistingInventarioItem == null)
                {

                    persona.Activo = true;
                    persona.Alias = FicPazt_cat_usuarios_Item.Alias;
                    persona.ApMaterno = FicPazt_cat_usuarios_Item.ApMaterno;
                    persona.ApPaterno = FicPazt_cat_usuarios_Item.ApPaterno;
                    persona.Borrado = false;
                    persona.FechaNac = "1/2/1996 12:00:00 AM";
                    persona.FechaReg = dta_string;
                    persona.FechaUltMod = dta_string;
                    persona.Nombre = FicPazt_cat_usuarios_Item.Nombre;
                    persona.RutaFoto = FicPazt_cat_usuarios_Item.RutaFoto;
                    persona.Sexo = FicPazt_cat_usuarios_Item.Sexo;
                    persona.UsuarioReg = FicPazt_cat_usuarios_Item.Usuario;
                    persona.UsuarioMod = FicPazt_cat_usuarios_Item.Usuario;

                    telefono.NumTelefono = FicPazt_cat_usuarios_Item.NumTelefono;
                    telefono.Activo = true;
                    telefono.Borrado = false;
                    telefono.FechaReg = dta_string;
                    telefono.FechaUltMod = dta_string;
                    telefono.Principal = true;
                    telefono.Referencia = "Nuevo";
                    telefono.UsuarioReg = FicPazt_cat_usuarios_Item.Usuario;
                    telefono.UsuarioMod = FicPazt_cat_usuarios_Item.Usuario;

                    await ficSQLiteConnection.InsertAsync(FicPazt_cat_usuarios_Item).ConfigureAwait(false);

                    await ficSQLiteConnection.InsertAsync(persona).ConfigureAwait(false);

                    telefono.ClaveReferencia = persona.IdPersona;
                    await ficSQLiteConnection.InsertAsync(telefono).ConfigureAwait(false);


                }
                else
                {

                    await ficSQLiteConnection.UpdateAsync(FicPazt_cat_usuarios_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task<IList<cat_usuarios>> FicMetGetListCatUsuarios()
        {
            var items = new List<cat_usuarios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<cat_usuarios>().ToListAsync().ConfigureAwait(false);
            }
            return items;
        }

        public async Task<IList<cat_usuarios>> FicMetGetListCatUsuarios(string usuario, string contrasena)
        {

            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var items = await ficSQLiteConnection.Table<cat_usuarios>().Where(x => x.Usuario == usuario && x.Contrasena == contrasena)
                      .ToListAsync().ConfigureAwait(false);

                return items;
            }

        }

        public async Task<cat_usuarios> FitMetGetUsuario(string correo)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_usuarios>()
                        .Where(x => x.Correo == correo)
                        .FirstOrDefaultAsync();
                return FicPersonaItem;

            }
        }

        public async Task<cat_usuarios> FitMetGetUsuario(string usuario, string contrasena)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicPersonaItem = await ficSQLiteConnection.Table<cat_usuarios>()
                        .Where(x => x.Usuario == usuario && x.Contrasena == contrasena)
                        .FirstOrDefaultAsync();

                return FicPersonaItem;

            }
        }

        public async Task FicMetInsertNewCatPersonas(cat_personas FicPazt_cat_personas_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<cat_personas>()
                        .Where(x => x.IdPersona == FicPazt_cat_personas_Item.IdPersona)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");

                if (FicExistingInventarioItem == null)
                {
                    FicPazt_cat_personas_Item.FechaReg = dta_string;
                    FicPazt_cat_personas_Item.FechaUltMod = dta_string;
                    FicPazt_cat_personas_Item.UsuarioMod = FicPazt_cat_personas_Item.UsuarioReg;
                    FicPazt_cat_personas_Item.IdTipoGenOcupacion = 5;
                    FicPazt_cat_personas_Item.IdTipoGenEstadoCivil = 6;

                    await ficSQLiteConnection.InsertAsync(FicPazt_cat_personas_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPazt_cat_personas_Item.FechaUltMod = dta_string;
                    FicPazt_cat_personas_Item.UsuarioMod = FicPazt_cat_personas_Item.UsuarioReg;
                    FicPazt_cat_personas_Item.IdTipoGenOcupacion = 5;
                    FicPazt_cat_personas_Item.IdTipoGenEstadoCivil = 6;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_cat_personas_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveCatPersonas(cat_personas FicPaZt_cat_personas_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_cat_personas_Item);
        }

        public async Task<IList<cat_personas>> FicSearchCatPersonas(String search)
        {
            var items = new List<cat_personas>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<cat_personas>().Where(s =>
                s.CURP.Contains(search) || s.NumControl == search || s.RFC.Contains(search)).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion

        #region Instituto

        public async Task<IList<cat_institutos>> FicMetGetListInstitutos()
        {
            var items = new List<cat_institutos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<cat_institutos>().ToListAsync().ConfigureAwait(false);
            }
            return items;
        }

        public async Task<cat_institutos> FitMetGetInstituto(cat_personas FicPazt_cat_personas_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicInstitutoItem = await ficSQLiteConnection.Table<cat_institutos>()
                        .Where(x => x.IdInstituto == FicPazt_cat_personas_Item.IdInstituto)
                        .FirstOrDefaultAsync();

                if (FicInstitutoItem == null)
                {
                    return FicInstitutoItem;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region rh_cat_dir_web

        public async Task<IList<rh_cat_dir_web>> FicMetGetListRhCatDirWeb(int idPersona)
        {
            var items = new List<rh_cat_dir_web>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_dir_web>()
                    .Where(x => x.ClaveReferencia == idPersona).ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetInsertNewRhCatDirWeb(rh_cat_dir_web FicPazt_rh_cat_dir_web_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<rh_cat_dir_web>()
                        .Where(x => x.IdDirWeb == FicPazt_rh_cat_dir_web_Item.IdDirWeb)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");


                if (FicExistingInventarioItem == null)
                {
                    FicPazt_rh_cat_dir_web_Item.FechaReg = dta_string;
                    FicPazt_rh_cat_dir_web_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_dir_web_Item.UsuarioMod = FicPazt_rh_cat_dir_web_Item.UsuarioReg;
                    FicPazt_rh_cat_dir_web_Item.IdTipoGenDirWeb = 9;

                    await ficSQLiteConnection.InsertAsync(FicPazt_rh_cat_dir_web_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPazt_rh_cat_dir_web_Item.IdDirWeb = FicExistingInventarioItem.IdDirWeb;
                    FicPazt_rh_cat_dir_web_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_dir_web_Item.UsuarioMod = FicPazt_rh_cat_dir_web_Item.UsuarioReg;
                    FicPazt_rh_cat_dir_web_Item.IdTipoGenDirWeb = 9;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_rh_cat_dir_web_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveRhCatDirWeb(rh_cat_dir_web FicPaZt_rh_cat_dir_web_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_rh_cat_dir_web_Item);
        }

        public async Task<IList<rh_cat_dir_web>> FicSearchRhCatDirWeb(String search)
        {
            var items = new List<rh_cat_dir_web>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_dir_web>().Where(s => s.ClaveReferencia == Global.ClaveReferencia &&
               (s.DirWeb.Contains(search) || s.DesDirWeb.Contains(search))).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion

        #region rh_cat_domicilios

        public async Task<IList<rh_cat_domicilios>> FicMetGetListRhCatDomicilios(int idPersona)
        {
            var items = new List<rh_cat_domicilios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_domicilios>()
                    .Where(x => x.ClaveReferencia == idPersona).ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetInsertNewRhCatDomicilios(rh_cat_domicilios FicPazt_rh_cat_domicilios_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                var FicExistingInventarioItem = await ficSQLiteConnection.Table<rh_cat_domicilios>()
                        .Where(x => x.IdDomicilio == FicPazt_rh_cat_domicilios_Item.IdDomicilio)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");


                if (FicExistingInventarioItem == null)
                {
                    FicPazt_rh_cat_domicilios_Item.FechaReg = dta_string;
                    FicPazt_rh_cat_domicilios_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_domicilios_Item.UsuarioMod = FicPazt_rh_cat_domicilios_Item.UsuarioReg;
                    FicPazt_rh_cat_domicilios_Item.IdTipoGenDom = 8;

                    await ficSQLiteConnection.InsertAsync(FicPazt_rh_cat_domicilios_Item).ConfigureAwait(false);
                }
                else
                {
                    FicPazt_rh_cat_domicilios_Item.IdDomicilio = FicExistingInventarioItem.IdDomicilio;
                    FicPazt_rh_cat_domicilios_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_domicilios_Item.UsuarioMod = FicPazt_rh_cat_domicilios_Item.UsuarioReg;
                    FicPazt_rh_cat_domicilios_Item.IdTipoGenDom = 8;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_rh_cat_domicilios_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveRhCatDomicilios(rh_cat_domicilios FicPaZt_rh_cat_domicilios_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_rh_cat_domicilios_Item);
        }

        public async Task<IList<rh_cat_domicilios>> FicSearchRhCatDomicilios(String search)
        {
            var items = new List<rh_cat_domicilios>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_domicilios>().Where(s => s.ClaveReferencia == Global.ClaveReferencia && (
                s.Domicilio.Contains(search) || s.Pais.Contains(search) || s.Municipio.Contains(search))).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion

        #region rh_cat_telefonos

        public async Task<IList<rh_cat_telefonos>> FicMetGetListRhCatTelefonos(int idPersona)
        {
            var items = new List<rh_cat_telefonos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {

                items = await ficSQLiteConnection.Table<rh_cat_telefonos>().Where(x => x.ClaveReferencia == idPersona).ToListAsync().ConfigureAwait(false);
            }

            return items;
        }

        public async Task FicMetInsertNewRhCatTelefonos(rh_cat_telefonos FicPazt_rh_cat_telefonos_Item)
        {
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {



                var FicExistingInventarioItem = await ficSQLiteConnection.Table<rh_cat_telefonos>()
                        .Where(x => x.IdTelefono == FicPazt_rh_cat_telefonos_Item.IdTelefono)
                        .FirstOrDefaultAsync();

                DateTime dta = DateTime.Now.ToLocalTime();
                string dta_string = dta.ToString("yyyy-MM-dd");


                if (FicExistingInventarioItem == null)
                {
                    FicPazt_rh_cat_telefonos_Item.FechaReg = dta_string;
                    FicPazt_rh_cat_telefonos_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_telefonos_Item.UsuarioMod = FicPazt_rh_cat_telefonos_Item.UsuarioReg;
                    FicPazt_rh_cat_telefonos_Item.IdTipoGenTelefono = 10;

                    await ficSQLiteConnection.InsertAsync(FicPazt_rh_cat_telefonos_Item).ConfigureAwait(false);

                    /*
                    var Actualizar = await ficSQLiteConnection.Table<rh_cat_telefonos>()
                    .Where(x => x.ClaveReferencia == FicPazt_rh_cat_telefonos_Item.ClaveReferencia
                    && FicPazt_rh_cat_telefonos_Item.Principal == true && x.IdTelefono != FicPazt_rh_cat_telefonos_Item.IdTelefono).
                    ToListAsync();

                    if (Actualizar != null)
                    {
                        Actualizar.ForEach(x => x.Principal = false);
                        await ficSQLiteConnection.UpdateAsync(Actualizar).ConfigureAwait(false);
                    }*/
                }
                else
                {
                    FicPazt_rh_cat_telefonos_Item.IdTelefono = FicExistingInventarioItem.IdTelefono;
                    FicPazt_rh_cat_telefonos_Item.FechaUltMod = dta_string;
                    FicPazt_rh_cat_telefonos_Item.UsuarioMod = FicPazt_rh_cat_telefonos_Item.UsuarioReg;
                    FicPazt_rh_cat_telefonos_Item.IdTipoGenTelefono = 10;
                    await ficSQLiteConnection.UpdateAsync(FicPazt_rh_cat_telefonos_Item).ConfigureAwait(false);
                }

            }
        }

        public async Task FicMetRemoveRhCatTelefonos(rh_cat_telefonos FicPaZt_rh_cat_telefonos_Item)
        {
            await ficSQLiteConnection.DeleteAsync(FicPaZt_rh_cat_telefonos_Item);
        }

        public async Task<IList<rh_cat_telefonos>> FicSearchRhCatTelefonos(String search)
        {
            var items = new List<rh_cat_telefonos>();
            using (await ficMutex.LockAsync().ConfigureAwait(false))
            {
                items = await ficSQLiteConnection.Table<rh_cat_telefonos>().Where(s => s.ClaveReferencia == Global.ClaveReferencia && (
                s.CodPais.Contains(search) || s.NumTelefono.Contains(search))).ToListAsync().ConfigureAwait(false);


            }

            return items;
        }

        #endregion

    }
}
