using Microsoft.AspNetCore.Mvc;
using SalesApplication.Model;
using SalesApplication.Services;

namespace SalesApplication.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class SalesRecordsController : ControllerBase
    {
        private readonly ISalesRecordService _salesRecordService;

        public SalesRecordsController(ISalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesRecordById(int id)
        {
            var salesRecord = await _salesRecordService.GetSalesRecordByIdAsync(id);
            if (salesRecord == null)
                return NotFound();
            return Ok(salesRecord);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalesRecords()
        {
            var salesRecords = await _salesRecordService.GetAllSalesRecordsAsync();
            return Ok(salesRecords);
        }

        [HttpPost]
        public async Task<IActionResult> AddSalesRecord([FromBody] SalesRecord salesRecord)
        {
            await _salesRecordService.AddSalesRecordAsync(salesRecord);
            return CreatedAtAction(nameof(GetSalesRecordById), new { id = salesRecord.Id }, salesRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSalesRecord(int id, [FromBody] SalesRecord salesRecord)
        {
            if (id != salesRecord.Id)
                return BadRequest();
            await _salesRecordService.UpdateSalesRecordAsync(salesRecord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesRecord(int id)
        {
            await _salesRecordService.DeleteSalesRecordAsync(id);
            return NoContent();
        }

        [HttpGet("total-sales")]
        public async Task<IActionResult> GetTotalSales([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var totalSales = await _salesRecordService.GetTotalSalesAsync(startDate, endDate);
            return Ok(totalSales);
        }

    }
}
