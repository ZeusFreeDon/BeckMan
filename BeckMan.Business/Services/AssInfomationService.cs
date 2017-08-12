using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeckMan.Del;
using System.Data.Entity.Validation;

namespace BeckMan.Business.Services
{
    /// <summary>
    /// 经销商评估信息服务
    /// </summary>
    public class AssInfomationService
    {
        BeckManEntities dbContext;
        public AssInfomationService()
        {
            dbContext = new BeckManEntities();
        }

        public void Add(bec_AssInformation inforMation, int AearId, int PartionId)
        {

            try
            {
                inforMation.bec_Aear = new bec_Aear { Id = AearId };
                inforMation.bec_Partion = new bec_Partion { Id = PartionId };
                dbContext.Entry(inforMation.bec_Aear).State = System.Data.Entity.EntityState.Unchanged;
                dbContext.Entry(inforMation.bec_Partion).State = System.Data.Entity.EntityState.Unchanged;
                //bec_Aear Aear = dbContext.bec_AearSet.Find(AearId);
                //bec_Partion partion = dbContext.bec_PartionSet.Find(PartionId);
                //inforMation.bec_Aear = Aear;
                //inforMation.bec_Partion = partion;
                dbContext.bec_AssInformationSet.Add(inforMation);
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

        }
    }
}
