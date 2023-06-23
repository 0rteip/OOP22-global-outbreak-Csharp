using farabegoli.disease;

namespace farabegoli.diseasereader
{
    /**
     * Interfaccia che gestisce la lettura del file delle malattie.
     */
    public interface IDiseaseReader
    {
        /**
         * 
         * @return
         *         la lista di DiseaseData
         */
        List<DiseaseData> GetDiseases();
    }
}
