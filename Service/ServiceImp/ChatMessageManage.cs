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

namespace Service.ServiceImp
{
    public class ChatMessageManage : RepositoryBase<Domain.SYS_CHATMESSAGE>,IChatMessageManage
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

        public DbSet<SYS_CHATMESSAGE> dbSet
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

        public bool CreateStaticPage(string temppath, string path, SYS_CHATMESSAGE t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<SYS_CHATMESSAGE, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<SYS_CHATMESSAGE, bool>> predicate, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SYS_CHATMESSAGE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(SYS_CHATMESSAGE entity, bool IsCommit = true)
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

        public int DeleteList(List<SYS_CHATMESSAGE> t)
        {
            throw new NotImplementedException();
        }

        public bool DeleteList(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
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

        public Task<bool> DeleteListAsync(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
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

        public SYS_CHATMESSAGE Get(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<SYS_CHATMESSAGE> GetAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
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

        public bool IsExist(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

       

        public Task<IQueryable<SYS_CHATMESSAGE>> LoadAllAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LoadEnumerable(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SYS_CHATMESSAGE> LoadEnumerableAll(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SYS_CHATMESSAGE>> LoadEnumerableAllAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable> LoadEnumerableAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<SYS_CHATMESSAGE> LoadListAll(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<SYS_CHATMESSAGE>> LoadListAllAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public DbQuery<SYS_CHATMESSAGE> LoadQueryAll(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<DbQuery<SYS_CHATMESSAGE>> LoadQueryAllAsync(Expression<Func<SYS_CHATMESSAGE, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Modify(string table, Dictionary<string, object> dic, string where)
        {
            throw new NotImplementedException();
        }

        public IList<SYS_CHATMESSAGE> PageByListSql(string sql, IList<DbParameter> parameters, PageCollection page)
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

        public PageInfo<SYS_CHATMESSAGE> Query(IQueryable<SYS_CHATMESSAGE> query, int index, int PageSize)
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

        public bool Save(SYS_CHATMESSAGE entity)
        {
            throw new NotImplementedException();
        }

        public bool Save(SYS_CHATMESSAGE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync(SYS_CHATMESSAGE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int SaveList(List<SYS_CHATMESSAGE> t)
        {
            throw new NotImplementedException();
        }

        public bool SaveList(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
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

        public Task<bool> SaveListAsync(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }

        public bool SaveOrUpdate(SYS_CHATMESSAGE entity, bool isEdit)
        {
            throw new NotImplementedException();
        }

        public bool SaveOrUpdate(SYS_CHATMESSAGE entity, bool IsSave, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveOrUpdateAsync(SYS_CHATMESSAGE entity, bool IsSave, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public List<SYS_CHATMESSAGE> SelectBySql(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public List<T1> SelectBySql<T1>(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<List<SYS_CHATMESSAGE>> SelectBySqlAsync(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public Task<List<T1>> SelectBySqlAsync<T1>(string sql, params DbParameter[] para)
        {
            throw new NotImplementedException();
        }

        public bool Update(SYS_CHATMESSAGE entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SYS_CHATMESSAGE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SYS_CHATMESSAGE entity, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public int UpdateList(List<SYS_CHATMESSAGE> t)
        {
            throw new NotImplementedException();
        }

        public bool UpdateList(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
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

        public Task<bool> UpdateListAsync(List<SYS_CHATMESSAGE> T1, bool IsCommit = true)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class
        {
            throw new NotImplementedException();
        }
    }
}
