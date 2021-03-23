using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orden.BdContext;
using Orden.Model;

namespace Orden.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Orden
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try

            {
               
                var listarOdenes = await _context.Ordens.Include($"{nameof(Detalle)}.{nameof(Producto)}").ToListAsync();
                   
                //var listarOdenes = await _context.Ordens.ToListAsync();
                return Ok(listarOdenes);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // GET: api/Orden/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var listarOrden = await _context.Ordens.Include($"{nameof(Detalle)}.{nameof(Producto)}").FirstOrDefaultAsync(x => x.DetalleId ==  id);
               

               
                return Ok(listarOrden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // POST: api/Orden
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ordenn orden)
        {
            try
            {

                _context.Add(orden);
                await _context.SaveChangesAsync();
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT: api/Orden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ordenn orden)
        {
            try
            {
                if (id != orden.Id)
                {
                    return NotFound();
                }
                else
                {
                    //orden.Detalle = null;
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "La Orden Fue Actulizado Con Exito" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            // DELETE: api/Orden/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var orden = await _context.Ordens.FindAsync(id);
                var detalle = await _context.Detalles.FindAsync(id);
                var producto = await _context.Productos.FindAsync(id);
                if (orden == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Ordens.Remove(orden);
                    _context.Detalles.Remove(detalle);
                    _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "La Orden Fue Elimina Con Exito" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
