using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsMatch.Domain.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCode;

namespace IsMatch.Api.Controllers
{
    //    API                    说明              请求正文          响应正文
    //    GET /api/todo          获取所有待办事项   None             待办事项的数组
    //    GET /api/todo/{id}     按 ID 获取项       None            待办事项
    //    POST /api/todo         添加新项           待办事项         待办事项
    //    PUT /api/todo/{id}	 更新现有项         待办事项         None
    //    DELETE /api/todo/{id}  删除项             None             None
    /// <summary>
    /// 基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController<TEntity> : ControllerBase where TEntity : Entity<TEntity>, new()
    {
        /// <summary>
        /// 获取所有项
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual ActionResult<PageResult<IList<TEntity>>> GetList(NewLife.Data.PageParameter pager)
        {
            var list = Entity<TEntity>.Search(null, pager);
            var result = PageResult<IList<TEntity>>.FromPager(pager);
            result.Data = list;
            return result;
        }

        /// <summary>
        /// 按 ID 获取项 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual ActionResult<AjaxResult<TEntity>> GetById(long id)
        {
            var data = Entity<TEntity>.FindByKey(id);
            if (data == null)
            {
                return new AjaxResult<TEntity> { Message = "该记录不存在，请检查" };
            }

            return new AjaxResult<TEntity> { Status = 1, Data = data };
        }

        /// <summary>
        /// 添加/更新 新项
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult<AjaxResult<TEntity>> PostTEntity(TEntity entity)
        {
            var ret = entity.Save();
            if (ret == 0)
            {
                return new AjaxResult<TEntity> { Message = "保存失败" };
            }

            return new AjaxResult<TEntity> { Status = 1, Data = entity };
        }

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public virtual ActionResult<AjaxResult<TEntity>> PutTEntity(long id)
        {
            var data = Entity<TEntity>.FindByKey(id);
            if (data == null)
            {
                return new AjaxResult<TEntity> { Message = "该记录不存在，无法删除！" };
            }
            var ret = data.Delete();

            if (ret == 0)
            {
                return new AjaxResult<TEntity> { Message = "该记录删除失败！" };
            }

            return new AjaxResult<TEntity> { Status = 1 };
        }
    }
}