using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Glacier;
using Amazon.Glacier.Transfer;
using Amazon.Runtime;


namespace Datos
{
    public class AWSGlacierS3
    {
        private static ArchiveTransferManager manager;
        private static string vaultName = "imgDepartamentos";

        public bool CargaArchivo()
        {
            bool resultado = false;
            try
            {

            }
            catch (AmazonGlacierException ex)
            {
                throw ex;
            }
            catch (AmazonServiceException ex)
            {
                throw ex;
            }
            return resultado;
        }

    }
}
