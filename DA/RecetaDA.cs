using Abstracciones.DA;
using Abstracciones.Modelos;
using Dapper;
using Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class RecetaDA : IRecetaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public RecetaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarReceta(Receta receta)
        {
            string sql = @"[AgregarReceta]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new
            {
                Paciente = receta.Paciente,
                Medico = receta.Medico,
                FechaEmision = receta.FechaEmision,
                Medicamento = receta.Medicamento,
                Instrucciones = receta.Instrucciones,
                Expira = receta.Expira,
                Comentarios = receta.Comentarios,
                Estado = receta.Estado
            });
            return (Guid)Consulta;
        }

        public async Task<Guid> EliminarReceta(Guid id)
        {
            string sql = @"[EliminarReceta]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new {Id = id});
            return id;
        }

        public async Task<Guid> ModificarEstado(Guid id, Receta receta)
        {
            string sql = @"[spTransicionEstado]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new
            {
                RecetaId = receta.Id,
                PacienteEsperado = receta.Paciente,
                MedicoEsperado = receta.Medico,
                FechaEmisionEsperada = receta.FechaEmision,
                MedicamentoEsperado = receta.Medicamento,
                InstruccionesEsperadas = receta.Instrucciones,
                ExpiraEsperada = receta.Expira,
                ComentariosEsperados = receta.Comentarios,
                NuevoEstado = receta.Estado
            });
            return id;




        }

        public async Task<Guid> ModificarReceta(Guid id, Receta receta)
        {
            string sql = @"[ModificarReceta]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new
            {
                Id = id,
                Paciente = receta.Paciente,
                Medico = receta.Medico,
                FechaEmision = receta.FechaEmision,
                Medicamento = receta.Medicamento,
                Instrucciones = receta.Instrucciones,
                Expira = receta.Expira,
                Comentarios = receta.Comentarios,
                Estado = receta.Estado
            });
            return id;
        }

        public async Task<IEnumerable<Receta>> ObtenerReceta()
        {
            string sql = @"[ObtenerTodasRecetas]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Receta>(sql);
            return ConvertirListaRecetaDBAModelo(Consulta.ToList());
        }

        public async Task<Receta> ObtenerRecetaPorId(Guid id)
        {
            string sql = @"[ObtenerRecetaPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Receta>(sql, new {Id = id});
            return ConvertirRecetaDBAModelo(Consulta.First());
        }

        public async Task<Receta> ObtenerCamposRecetaPorId(Guid id)
        {
            string sql = @"[ObtenerCamposRecetaPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Receta>(sql, new { Id = id });
            return ConvertirRecetaDBAModelo(Consulta.First());
        }


        private IEnumerable<Abstracciones.Modelos.Receta> ConvertirListaRecetaDBAModelo(IEnumerable<Abstracciones.Entities.Receta> Recetas)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Receta, Abstracciones.Modelos.Receta>(Recetas);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Receta ConvertirRecetaDBAModelo(Abstracciones.Entities.Receta Receta)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Receta, Abstracciones.Modelos.Receta>(Receta);
            return resultadoConversion;
        }
    }
}
