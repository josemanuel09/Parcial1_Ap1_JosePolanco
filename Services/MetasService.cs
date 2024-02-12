using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_JosePolanco.DAL;
using Parcial1_Ap1_JosePolanco.Model;
using System.Linq.Expressions;

namespace Parcial1_Ap1_JosePolanco.Services
{
    public class MetasService
    {
      
            private readonly Contexto _contexto;

            public MetasService(Contexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<bool> Insertar(Metas metas)
            {
                _contexto.Metas.Add(metas);
                return await _contexto.SaveChangesAsync() > 0;
            }

            public async Task<bool> Modificar(Metas metas)
            {
                var a = await _contexto.Metas.FindAsync(metas.MetaId);
                _contexto.Entry(a!).State = EntityState.Detached;
                _contexto.Entry(metas).State = EntityState.Modified;
                return await _contexto.SaveChangesAsync() > 0;
            }

            public async Task<bool> Existe(int metaId)
            {
                return await _contexto.Metas
                    .AnyAsync(a => a.MetaId == metaId);
            }

            public async Task<bool> Guardar(Metas metas)
            {
                if (!await Existe(metas.MetaId))
                    return await Insertar(metas);
                else
                    return await Modificar(metas);
            }

            public async Task<bool> Eliminar(Metas metas)
            {
                var cantidad = await _contexto.Metas
                     .Where(a => a.MetaId == metas.MetaId)
                     .ExecuteDeleteAsync();
                return cantidad > 0;
            }


            public async Task<Metas?> Buscar(int metaId)
            {
                return await _contexto.Metas
                    .Where(a => a.MetaId == metaId)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }

            public List<Metas> Listar(Expression<Func<Metas, bool>> criterio)
            {
                return _contexto.Metas
                    .Where(criterio)
                    .AsNoTracking()
                    .ToList();
            }
        }
    }

