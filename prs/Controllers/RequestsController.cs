﻿using System;
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
    public class RequestsController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public RequestsController(PrsDbContext context)
        {
            _context = context;
        }


        //Set request to APPROVED
        [HttpPut("/api/requests/approved/{id}")]
        public async Task<IActionResult> PutRequestApproved(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = "APPROVED";
            await _context.SaveChangesAsync();
            return NoContent();
        }


        // Set request to Rejected
        [HttpPut("/api/requests/rejected/{id}")]
        public async Task<IActionResult> PutRequestRejected(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = "REJECTED";
            await _context.SaveChangesAsync();
            return NoContent();

        }

        //Set request to Review or Approved base on Total = 50
        [HttpPut("/api/Requests/Review/{id}")]
        public async Task<IActionResult> PutRequestReview(int Id)
        {
            var request = await _context.Requests.FindAsync(Id);

            if (request == null)
            {
                return NotFound();
            }
            if (request.Total <= 50)
            {
                request.Status = "APPROVED";

            }
            else request.Status = "REVIEW";

            await _context.SaveChangesAsync();

            return NoContent();

        }


        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }


        // GET: api/Requests with Review status
        [HttpGet("/api/requests/review")]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequestsReview()
        {
            return await _context.Requests.Where(r => r.Status == "REVIEW").ToListAsync();
            
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
