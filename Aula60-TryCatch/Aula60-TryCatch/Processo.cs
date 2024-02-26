using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula60_TryCatch
{
    public class Processo
    {
        public void LerArquivo()
        {
            try
            {
                FileInfo arquivo = new FileInfo("c:\\Teste\\Documento.txt");
                StreamReader sr = arquivo.OpenText();
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine("Tivemos um problema com o diretório");
                EnviarEmailInfra(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Tivemos um problema com o arquivo");
                EnviarEmailDev(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tivemos um problema no sistema");
                EnviarEmailDeErrosGenericos(ex.Message);
            }
        }

        private void EnviarEmailDev(string erro)
        {
            //body = erro
        }

        private void EnviarEmailInfra(string erro)
        {
            //body = erro
        }

        private void EnviarEmailDeErrosGenericos(string erro)
        {
            //body = erro
        }



    }
}
