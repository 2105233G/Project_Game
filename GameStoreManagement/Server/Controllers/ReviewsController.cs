using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStoreManagement.Shared.Domain;
using GameStoreManagement.Server.IRepository;

namespace GameStoreManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReviewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reviews

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var Reviews = await _unitOfWork.Reviews.GetAll(includes: q => q.Include(x => x.Game));
            return Ok(Reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {

            var Review = await _unitOfWork.Reviews.Get(q => q.Id == id);

            if (Review == null)
            {
                return NotFound();
            }

            return Ok(Review);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review Review)
        {
            if (id != Review.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Reviews.Update(Review);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review Review)
        {

            await _unitOfWork.Reviews.Insert(Review);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetReview", new { id = Review.Id }, Review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var Review = await _unitOfWork.Reviews.GetAll(q => q.Id == id);
            if (Review == null)
            {
                return NotFound();
            }




            await _unitOfWork.Reviews.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ReviewExists(int id)
        {
            var Review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            return Review != null;
        }
    }
}
