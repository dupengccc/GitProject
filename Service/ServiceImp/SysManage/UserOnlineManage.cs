using Service.IService.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;
using System.Collections;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace Service.ServiceImp.SysManage
{
    public class UserOnlineManage : IUserOnlineManage
    {
        public bool Committed
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public MyConfig Config
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Context Context
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<UserOnline> dbSet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DbContextTransaction Transaction
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public bool CreateFileHtmlByTemp(string result, string createpath)
        {
            throw new NotImplementedException();
        }

        public bool CreateStaticPage(string temppath, string path, UserOnline t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<UserOnline, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public int DeleteBySql(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public int DeleteList(List<UserOnline> t)
        {
            throw new NotImplementedException();
        }

        public int DeleteList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }

        public object ExecuteProc(string procname, params DbParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public object ExecuteQueryProc(string procname, params DbParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public object ExecuteSqlCommand(Dictionary<string, object> sqllist)
        {
            throw new NotImplementedException();
        }

        public object ExecuteSqlCommand(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public object ExecuteSqlQuery(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public UserOnline Get(Expression<Func<UserOnline, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Encoding GetEncoding(string html)
        {
            throw new NotImplementedException();
        }

        public string GetHtml(string url, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(Expression<Func<UserOnline, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserOnline> LoadAll(Expression<Func<UserOnline, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LoadEnumerable(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserOnline> LoadEnumerableAll(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<UserOnline> LoadListAll(Expression<Func<UserOnline, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DbQuery<UserOnline> LoadQueryAll(Expression<Func<UserOnline, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<UserOnline> PageByListSql(string sql, IList<DbParameter> parameters, PageCollection page)
        {
            throw new NotImplementedException();
        }

        public IList<T1> PageByListSql<T1>(string sql, IList<DbParameter> parameters, PageCollection page)
        {
            throw new NotImplementedException();
        }

        public PageInfo Query(IQueryable query, int index, int pagesize)
        {
            throw new NotImplementedException();
        }

        public PageInfo<UserOnline> Query(IQueryable<UserOnline> query, int index, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PageInfo Query(int index, int pageSize, string sql, string orderby, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public PageInfo Query(int index, int pageSize, string tableName, string field, string filter, string orderby, string group, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public PageInfo<object> Query<TEntity, TOrderBy>(int index, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public dynamic QueryDynamic<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc)
            where TEntity : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public bool Save(UserOnline entity)
        {
            throw new NotImplementedException();
        }

        public int SaveList(List<UserOnline> t)
        {
            throw new NotImplementedException();
        }

        public int SaveList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool SaveOrUpdate(UserOnline entity, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public List<UserOnline> SelectBySql(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<T1> SelectBySql<T1>(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserOnline entity)
        {
            throw new NotImplementedException();
        }

        public int UpdateList(List<UserOnline> t)
        {
            throw new NotImplementedException();
        }

        public int UpdateList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }
    }
}
