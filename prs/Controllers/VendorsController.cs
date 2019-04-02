using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prs.Models;
 

namespace prs_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public VendorsController(PrsDbContext context)
        {
            _context = context;
        }

        // GET: api/Vendors/po/5
        [HttpGet("/api/Vendors/Po/{id}")]
        public async Task<ActionResult<Po>> GetPo(int id)
        {

            var po = new Po();
            po.Vendor = await _context.Vendors.FindAsync(id);
            Dictionary<int, RequestLine> lines = new Dictionary<int, RequestLine>();
            var reqs = await _context.Requests
                                    .Where(r => r.Status.Equals("APPROVED"))
                                    .ToListAsync();
            foreach (var r in reqs)
            {
                foreach (var l in r.RequestLines)
                {
                    if (l.Product.VendorId == id)
                    {
                        if (lines.Keys.Contains(l.ProductId))
                        {
                            lines[l.ProductId].Quantity += l.Quantity;
                        }
                        else
                        {
                            lines.Add(l.ProductId, l);
                        }
                    }
                }
            }
            foreach (var key in lines.Keys)
            {
                po.PoLines.Add(lines[key]);
            }

            po.Total = po.PoLines.Sum(l => l.Quantity * l.Product.Price);

            return Ok(po);
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }

        // PUT: api/Vendors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendors
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendor>> DeleteVendor(int id)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }

        private bool VendorExists(int id)
        {
            return _context.Vendors.Any(e => e.Id == id);
        }
    }
}
