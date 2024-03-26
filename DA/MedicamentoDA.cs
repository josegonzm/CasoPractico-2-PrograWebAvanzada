using Abstracciones.DA;
using Abstracciones.Modelos;
using DA.Repositorio;
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
    public class MedicamentoDA : IMedicamentoDA
    {


        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public MedicamentoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorioDapper();
        }

        public async Task<Guid> AgregarMedicamento(Medicamento medicamento)
        {
            string sql = @"[AgregarMedicamento]";
            var Consulta = await _sqlConnection.ExecuteScalarAsync(sql, new { Nombre = medicamento.Nombre, Indicaciones = medicamento.Indicaciones, Fecha_Caducidad = medicamento.Fecha_Caducidad, Efectos_Secundarios = medicamento.Efectos_Secundarios, Fabricante = medicamento.Fabricante });
            return (Guid)Consulta;
        }

        public async Task<Guid> EliminarMedicamento(Guid id)
        {
            string sql = @"[EliminarMedicamento]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id });
            return id;
        }

        public async Task<Guid> ModificarMedicamento(Guid id, Medicamento medicamento)
        {
            string sql = @"[ModificarMedicamento]";
            var Consulta = await _sqlConnection.ExecuteAsync(sql, new { Id = id, Nombre = medicamento.Nombre, Indicaciones = medicamento.Indicaciones, Fecha_Caducidad = medicamento.Fecha_Caducidad, Efectos_Secundarios = medicamento.Efectos_Secundarios, Fabricante = medicamento.Fabricante });
            return id;
        }

        public async Task<IEnumerable<Medicamento>> ObtenerMedicamento()
        {
            string sql = @"[ObtenerTodosMedicamentos]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Medicamento>(sql);
            return ConvertirListaMedicamentoDBAModelo(Consulta.ToList());
        }

        public async Task<Medicamento> ObtenerMedicamentoPorId(Guid id)
        {
            string sql = @"[ObtenerMedicamentoPorId]";
            var Consulta = await _sqlConnection.QueryAsync<Abstracciones.Entities.Medicamento>(sql, new { Id = id });
            return ConvertirMedicamentoDBAModelo(Consulta.First());
        }



        private IEnumerable<Abstracciones.Modelos.Medicamento> ConvertirListaMedicamentoDBAModelo(IEnumerable<Abstracciones.Entities.Medicamento> Medicamentos)
        {
            var resultadoConversion = Convertidor.ConvertirLista<Abstracciones.Entities.Medicamento, Abstracciones.Modelos.Medicamento>(Medicamentos);
            return resultadoConversion;
        }
        private Abstracciones.Modelos.Medicamento ConvertirMedicamentoDBAModelo(Abstracciones.Entities.Medicamento Medicamento)
        {
            var resultadoConversion = Convertidor.Convertir<Abstracciones.Entities.Medicamento, Abstracciones.Modelos.Medicamento>(Medicamento);
            return resultadoConversion;
        }




    }
}
