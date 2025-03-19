using ChillLancer.BusinessService.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ChillLanver.Odata.Controllers
{
    public class OdataTempController : Controller
    {
        [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IQueryable<ProjectBM>>> GetAppointments()
        {
            //var projects = await _projectService.GetProjects();

            //if (!projects.Any()) return NotFound();


            //return Ok(projects.AsQueryable());
            throw new NotImplementedException();
        }
    }
}
