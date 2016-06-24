using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataLayer;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [NotImplExceptionFilter]
    public class CoreItemsController : ApiController
    {
        DataSampleEntities coreItemData;
        public CoreItemsController() {
            coreItemData = new DataSampleEntities();
        }

        public HttpResponseMessage Get(string itemNumber)
        {
            CoreItem cItem;
            cItem = coreItemData.CoreItems.Where(x => x.ItemNumber == itemNumber).FirstOrDefault();
            if (cItem != null)
                return Request.CreateResponse(HttpStatusCode.OK, cItem);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Item not found in system with Item Number:" + itemNumber);
        }

        //public IHttpActionResult Get(string itemNumber)
        //{
        //    CoreItem cItem;
        //    cItem = coreItemData.CoreItems.Where(x => x.ItemNumber == itemNumber).FirstOrDefault();
        //    if (cItem != null)
        //        return Ok(cItem);
        //    else
        //        return NotFound();
        //}
        [NotImplExceptionFilter]
        public IEnumerable<CoreItem> Get()
        {

            return coreItemData.CoreItems.ToList(); 
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] CoreItem addCoreItem)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    var errors = new List<string>();
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                    //return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                coreItemData.CoreItems.Add(addCoreItem);
                coreItemData.SaveChanges();
                return Request.CreateResponse<CoreItem>(HttpStatusCode.Created, addCoreItem);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex.Message);
            }
            
        }


        public CoreItem Put(string itemNumber, CoreItem coreItemToUpdate)
        {
            CoreItem coreItem =  coreItemData.CoreItems.Where(x => x.ItemNumber == itemNumber).FirstOrDefault();

            coreItem.ItemDescription = coreItemToUpdate.ItemDescription;
            coreItem.Price = coreItemToUpdate.Price;

            coreItemData.SaveChanges();
           

            return coreItemToUpdate;
        }
    }
}
