using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class MarcaVehiculoService
    {
        private readonly IDataAccess sql;

        public MarcaVehiculoService(IDataAccess _sql)
        {
            sql = _sql;
        }
        public async Task<IEnumerable<MarcaVehiculoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<MarcaVehiculoEntity>(sp: "MarcaVehiculoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MarcaVehiculoEntity>GetById(MarcaVehiculoEntity entity)
        {
            try
            {
                var result=sql.QueryFirstAsync<MarcaVehiculoEntity>(sp:"MarcaVehiculoObtener",Param: new
                    {
                        entity.MarcaVehiculoId
                    }
                 );
            return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
