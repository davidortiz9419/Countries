namespace Countries.Backend.Helpers
{
    using Domain;
    using Models;
    using System;
    using System.Threading.Tasks;

    public class DBHelper
    {
        public async static Task<Response> SaveChanges(DataContextLocal db)
        {
            try
            {
                await db.SaveChangesAsync();
                return new Response { IsSuccess = true, };
            }
            catch (Exception ex)
            {
                var response = new Response { IsSuccess = false, };
                if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("_Index"))
                {
                    response.Message = "Hay un registro con el mismo valor";
                }
                else if (ex.InnerException != null &&
                    ex.InnerException.InnerException != null &&
                    ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "El registro no se puede eliminar porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }

                return response;
            }
        }
    }
}