// 2020-12-27, Bruce

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComFram
{
    interface IDao
    {
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<IModel> FindListByName(string name);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IModel FindByID(int id);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="nPageIndex"></param>
        /// <param name="nPageSize"></param>
        /// <returns></returns>
        List<IModel> FindListByPage(int nPageIndex, int nPageSize);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InsertData(IModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteData(IModel model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateData(IModel model);

    }

}
