using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;

namespace Service.IService.SysManage
{
    public class ICodeManage : IRepository<Domain.SYS_CODE>
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

        public DbSet<SYS_CODE> dbSet
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

        public DbContext _Context
        {
            get
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

        public bool CreateStaticPage(string temppath, string path, SYS_CODE t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<SYS_CODE, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<SYS_CODE, bool>> predicate, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<SYS_CODE, bool>> predicate, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int DeleteBySql(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBySqlAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public int DeleteList(List<SYS_CODE> t)
        {
            throw new NotImplementedException();
        }

        public bool DeleteList(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int DeleteList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool DeleteList<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteListAsync(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class
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

        public SYS_CODE Get(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<SYS_CODE> GetAsync(Expression<Func<SYS_CODE, bool>> predicate)
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

        public bool IsExist(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SYS_CODE> LoadAll(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<SYS_CODE>> LoadAllAsync(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LoadEnumerable(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SYS_CODE> LoadEnumerableAll(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SYS_CODE>> LoadEnumerableAllAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable> LoadEnumerableAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<SYS_CODE> LoadListAll(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SYS_CODE>> LoadListAllAsync(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DbQuery<SYS_CODE> LoadQueryAll(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<DbQuery<SYS_CODE>> LoadQueryAllAsync(Expression<Func<SYS_CODE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Modify(string table, Dictionary<string, object> dic, string where)
        {
            throw new NotImplementedException();
        }

        public IList<SYS_CODE> PageByListSql(string sql, IList<DbParameter> parameters, PageCollection page)
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

        public PageInfo<SYS_CODE> Query(IQueryable<SYS_CODE> query, int index, int PageSize)
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

        public Task<dynamic> QueryDynamicAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc)
            where TEntity : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> QueryEntityAsync<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc)
            where TEntity : class
            where TResult : class
        {
            throw new NotImplementedException();
        }

        public List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<List<object>> QueryObjectAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public bool Save(SYS_CODE entity)
        {
            throw new NotImplementedException();
        }

        public bool Save(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int SaveList(List<SYS_CODE> t)
        {
            throw new NotImplementedException();
        }

        public bool SaveList(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int SaveList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool SaveList<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveListAsync(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool SaveOrUpdate(SYS_CODE entity, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public bool SaveOrUpdate(SYS_CODE entity, bool IsSave, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveOrUpdateAsync(SYS_CODE entity, bool IsSave, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public List<SYS_CODE> SelectBySql(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<T1> SelectBySql<T1>(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<List<SYS_CODE>> SelectBySqlAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<List<T1>> SelectBySqlAsync<T1>(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public bool Update(SYS_CODE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SYS_CODE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateList(List<SYS_CODE> t)
        {
            throw new NotImplementedException();
        }

        public bool UpdateList(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateList<T1>(List<T1> t) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool UpdateList<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateListAsync(List<SYS_CODE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }
    }
}
