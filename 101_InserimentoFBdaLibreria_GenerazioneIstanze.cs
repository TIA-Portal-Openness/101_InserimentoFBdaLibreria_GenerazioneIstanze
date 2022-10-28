using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using System.IO;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.Library.MasterCopies;

namespace App_Esempio_Openness
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<TiaPortalProcess> mieiProcessiTIAAperti = TiaPortal.GetProcesses();
            TiaPortalProcess mioProcessoTIAPortal = mieiProcessiTIAAperti[0];
            TiaPortal mioTIAPortalAperto = mioProcessoTIAPortal.Attach();
            Project mioProgettoTIA = mioTIAPortalAperto.Projects[0];

            //Creo l'oggetto C# associato al PLC già presente nel progetto TIA Portal
            Device StazionePLC = mioProgettoTIA.Devices[0];
            DeviceItem mioPLC = StazionePLC.DeviceItems[1];

            //Creo l'oggetto C# associato al blocco di libreria già presente nel progetto TIA Portal
            ProjectLibrary miaLibreriaDiProgetto = mioProgettoTIA.ProjectLibrary;
            MasterCopySystemFolder miaCartellaCopieMaster = miaLibreriaDiProgetto.MasterCopyFolder;
            MasterCopy mioBloccoFB_Generico = miaCartellaCopieMaster.MasterCopies[0];

            //Creo l'oggetto C# associato alla cartella blocchi del programma PLC
            SoftwareContainer mioContenitoreSoftware = mioPLC.GetService<SoftwareContainer>();
            PlcSoftware mioSoftwarePLC = mioContenitoreSoftware.Software as PlcSoftware;
            PlcBlockGroup miaCartellaBlocchiPLC = mioSoftwarePLC.BlockGroup;

            //Importo blocco di libreria nel progetto
            miaCartellaBlocchiPLC.Blocks.CreateFrom(mioBloccoFB_Generico);

            Console.WriteLine("Blocco FB " + mioBloccoFB_Generico.Name + " Importato nella cartella blocchi del PLC");
            Console.WriteLine("Quante DB di istanza vuoi creare di questo blocco? (Inserisci un numero e premi invio");
            int mioNumeroIstanze = Convert.ToInt32(Console.ReadLine());

            //Creo le istanze richieste

            for (int index = 1; index <= mioNumeroIstanze; index++)
            {
                miaCartellaBlocchiPLC.Blocks.CreateInstanceDB(mioBloccoFB_Generico.Name + "_Istanza" + Convert.ToString(index), true, 5, "Motore");
            };
            //           
        }
    }
}