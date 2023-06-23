using System.Collections.Generic;

namespace farabegoli.disease
{
    public class DiseaseDataList
    {
        private List<DiseaseData> disease = new List<DiseaseData>();

        /**
        * 
        * @return
        *         Lista di DiseaseData
        */
        public List<DiseaseData> GetDisease()
        {
            return new List<DiseaseData>(this.disease);
        }

        /**
        * salva tutti i DiseaseData qui.
        * 
        * @param disease
        *                Lista di DiseaseData
        */
        public void SetDisease(List<DiseaseData> disease)
        {
            this.disease = new List<DiseaseData>(disease);
        }
    }
}