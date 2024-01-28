using AutoMapper;
using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyAPI.ConfigureService.ServiceCollection;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTablesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilesService _file;

        private readonly ITableService<BranchTables> _tableService;
        public ManageTablesController(
            IMapper mapper,
            ITableService<BranchTables> tableService,
            IFilesService file
        )
        {
            _mapper = mapper;
            _tableService = tableService;
            _file = file;
        }
        [HttpPost]
        [Route("AddTable")]
        public async Task<IActionResult> AddTable([FromBody] BranchTablesDTO company)
        {
            var temp = _mapper.Map<BranchTables>(company);
            temp.TableQrPath = await _file.GenerateQRForTables("", company.BranchId, company.CompanyId);
            _tableService.InsertAsync(temp);
            return Ok(await _tableService.SaveChangesAsync());
        }

        [HttpGet]
        [Route("GetAllTable")]
        public async Task<ActionResult<IEnumerable<BranchTables>>> GetAllTable(int? TableId = null, int? BranchId = null,bool? TakeAway=null)
        {
            return Ok(await _tableService.GetBranchTablesAsync(TableId,BranchId,TakeAway));
        }

        [HttpPut]
        [Route("UpdateTable")]
        public async Task<IActionResult> UpdateTable([FromBody] BranchTablesDTO table, int Id)
        {
            var data = await _tableService.GetBranchTablesAsync(Id, table.BranchId);
            var tableData = data.FirstOrDefault();
            if (tableData == null)
            {
                return NotFound(false);
            }
            _mapper.Map(table, tableData);
            tableData.ModifiedDate = DateTime.UtcNow;
            _tableService.UpdateAsync(tableData);
            return Ok(await _tableService.SaveChangesAsync());
        }

        [HttpDelete]
        [Route("DeleteTable")]
        public async Task<IActionResult> DeleteBranchStaffItem([FromBody] BranchTablesDTO table, int Id)
        {
            var data = await _tableService.GetBranchTablesAsync(Id, table.BranchId);
            var tableData = data.FirstOrDefault();
            if (tableData == null)
            {
                return NotFound(false);
            }
            tableData.IsDeleted = true;
            tableData.ModifiedDate = DateTime.UtcNow;
            _tableService.UpdateAsync(tableData);
            return Ok(await _tableService.SaveChangesAsync());
        }
    }
}
