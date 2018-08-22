using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEvaTec.Models.Personas
{
    public class cat_institutos
    {
        [PrimaryKey, Unique]
        public int IdInstituto { get; set; }
        public string DesInstituto { get; set; }
        public string Alias { get; set; }
        public string Matriz { get; set; }
    }

    public class cat_personas
    {
        [PrimaryKey, AutoIncrement]
        public int IdPersona { get; set; }
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string FechaNac { get; set; }
        public string TipoPersona { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        public int IdInstituto { get; set; }
        public int IdTipoGenOcupacion { get; set; }
        public int IdGenOcupacion { get; set; }
        public int IdTipoGenEstadoCivil { get; set; }
        public int IdGenEstadoCivil { get; set; }

        public override string ToString()
        {
            return string.Format("[cat_personas: IdInstituto={0}, IdTipoGenOcupacion={1}, IdGenOcupacion={2}, IdTipoGenEstadoCivil={3}," +
                " IdGenEstadoCivil={4}], NumControl={5},  Nombre={6}, ApPaterno={7}, ApMaterno={8}, RFC={9}, " +
                " CURP={10}, FechaNac={11}, TipoPersona={12}, Sexo={13}, RutaFoto={14}, Alias={15}, FechaReg={16}," +
              " UsuarioReg={17}, FechaUltMod={18}, UsuarioMod={19}, Activo={20}, Borrado={21}",
                               " IdPersona={22}",
                                 IdInstituto, IdTipoGenOcupacion, IdGenOcupacion, IdTipoGenEstadoCivil, IdGenEstadoCivil,
                                NumControl, Nombre, ApPaterno, ApMaterno, RFC, CURP, FechaNac, TipoPersona, Sexo,
                                RutaFoto, Alias, FechaReg, UsuarioReg, FechaUltMod, UsuarioMod, Activo, Borrado
                                 , IdPersona);
        }
    }

    public class rh_cat_dir_web
    {
        [PrimaryKey, AutoIncrement]
        public int IdDirWeb { get; set; }
        public string DesDirWeb { get; set; }
        public string DirWeb { get; set; }
        public bool Principal { get; set; }
        public int IdTipoGenDirWeb { get; set; }
        public int IdGenDirWeb { get; set; }
        public int ClaveReferencia { get; set; }
        public string Referencia { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
    }

    public class rh_cat_domicilios
    {
        [PrimaryKey, AutoIncrement]
        public int IdDomicilio { get; set; }
        public string Domicilio { get; set; }
        public string EntreCalle1 { get; set; }
        public string EntreCalle2 { get; set; }
        public string CodigoPostal { get; set; }
        public string Coordenadas { get; set; }
        public bool Principal { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Localidad { get; set; }
        public string Colonia { get; set; }
        public string Referencia { get; set; }
        public int ClaveReferencia { get; set; }
        public string TipoDomicilio { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        public int IdTipoGenDom { get; set; }
        public int IdGenDom { get; set; }
    }

    public class rh_cat_telefonos
    {
        [PrimaryKey, AutoIncrement]
        public int IdTelefono { get; set; }
        public string CodPais { get; set; }
        public string NumTelefono { get; set; }
        public string NumExtension { get; set; }
        public bool Principal { get; set; }
        public int ClaveReferencia { get; set; }
        public string Referencia { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }
        public int IdTipoGenTelefono { get; set; }
        public int IdGenTelefono { get; set; }
    }

    public class cat_usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public string NumTelefono { get; set; }
        public string FechaReg { get; set; }
        public string FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        public bool Activo { get; set; }
        public bool Borrado { get; set; }

    }
}
