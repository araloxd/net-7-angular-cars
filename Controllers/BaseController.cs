using Microsoft.AspNetCore.Mvc;
using net_7_angular_cars.Models;
using net_7_angular_cars.Repositories;

public class BaseController<TEntity, TRepository> : ControllerBase
    where TEntity : BaseModel
    where TRepository : IRepository<TEntity>
{
    protected readonly TRepository Repository;

    public BaseController(TRepository repository)
    {
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    // GET: api/[Entity]
    [HttpGet]
    public virtual ActionResult<IEnumerable<TEntity>> GetAll()
    {
        var entities = Repository.GetAll();
        return Ok(entities);
    }

    // GET: api/[Entity]/1
    [HttpGet("{id}")]
    public virtual ActionResult<TEntity> GetById(int id)
    {
        var entity = Repository.GetById(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    // POST: api/[Entity]
    [HttpPost]
    protected virtual ActionResult<TEntity> Create(TEntity entity)
    {
        if (entity == null)
        {
            return BadRequest("Invalid entity data.");
        }

        Repository.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    // PUT: api/[Entity]/1
    [HttpPut("{id}")]
    protected virtual IActionResult Modify(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest("Invalid entity ID.");
        }

        try
        {
            Repository.Update(id, entity);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error updating entity: {ex.Message}");
        }
    }

    // DELETE: api/[Entity]/1
    [HttpDelete("{id}")]
    protected virtual IActionResult Delete(int id)
    {
        try
        {
            Repository.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Error deleting entity: {ex.Message}");
        }
    }
}
