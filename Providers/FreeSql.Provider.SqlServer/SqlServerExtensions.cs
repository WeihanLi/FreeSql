﻿using FreeSql;
using FreeSql.Internal.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using FreeSql.Internal.CommonProvider;
#if microsoft
using Microsoft.Data.SqlClient;
#else
using System.Data.SqlClient;
#endif
using System.Threading.Tasks;

public static partial class FreeSqlSqlServerGlobalExtensions
{

    /// <summary>
    /// 特殊处理类似 string.Format 的使用方法，防止注入，以及 IS NULL 转换
    /// </summary>
    /// <param name="that"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string FormatSqlServer(this string that, params object[] args) => _sqlserverAdo.Addslashes(that, args);
    static FreeSql.SqlServer.SqlServerAdo _sqlserverAdo = new FreeSql.SqlServer.SqlServerAdo();

    /// <summary>
    /// SqlServer with(nolock) 查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="lockType"></param>
    /// <param name="rule">多表查询时的锁规则</param>
    /// <returns></returns>
    public static ISelect<T> WithLock<T>(this ISelect<T> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2> WithLock<T1, T2>(this ISelect<T1, T2> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3> WithLock<T1, T2, T3>(this ISelect<T1, T2, T3> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4> WithLock<T1, T2, T3, T4>(this ISelect<T1, T2, T3, T4> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5> WithLock<T1, T2, T3, T4, T5>(this ISelect<T1, T2, T3, T4, T5> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6> WithLock<T1, T2, T3, T4, T5, T6>(this ISelect<T1, T2, T3, T4, T5, T6> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7> WithLock<T1, T2, T3, T4, T5, T6, T7>(this ISelect<T1, T2, T3, T4, T5, T6, T7> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8> WithLock<T1, T2, T3, T4, T5, T6, T7, T8>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class => LocalWithLock(that, lockType, rule);

    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class where T15 : class => LocalWithLock(that, lockType, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> WithLock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> that, SqlServerLock lockType = SqlServerLock.NoLock, Dictionary<Type, bool> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class where T15 : class where T16 : class => LocalWithLock(that, lockType, rule);
    static TReturn LocalWithLock<TReturn>(TReturn query, SqlServerLock lockType, Dictionary<Type, bool> rule)
    {
        var selectProvider = query as Select0Provider;
        var oldalias = selectProvider._aliasRule;
        selectProvider._aliasRule = (type, old) =>
        {
            if (oldalias != null) old = oldalias(type, old);
            if (rule == null) return LocalAppendWithString(old, lockType.ToString());
            return rule.TryGetValue(type, out var trybool) && trybool ? LocalAppendWithString(old, lockType.ToString()) : old;
        };
        return query;
    }
    /// <summary>
    /// SqkServer with(index) 强制索引
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static ISelect<T> WithIndex<T>(this ISelect<T> that, string indexName, Dictionary<Type, string> rule = null) => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2> WithIndex<T1, T2>(this ISelect<T1, T2> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3> WithIndex<T1, T2, T3>(this ISelect<T1, T2, T3> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4> WithIndex<T1, T2, T3, T4>(this ISelect<T1, T2, T3, T4> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5> WithIndex<T1, T2, T3, T4, T5>(this ISelect<T1, T2, T3, T4, T5> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6> WithIndex<T1, T2, T3, T4, T5, T6>(this ISelect<T1, T2, T3, T4, T5, T6> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7> WithIndex<T1, T2, T3, T4, T5, T6, T7>(this ISelect<T1, T2, T3, T4, T5, T6, T7> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class => LocalWithIndex(that, indexName, rule);

    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class where T15 : class => LocalWithIndex(that, indexName, rule);
    public static ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> WithIndex<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this ISelect<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> that, string indexName, Dictionary<Type, string> rule = null) where T1 : class where T2 : class where T3 : class where T4 : class where T5 : class where T6 : class where T7 : class where T8 : class where T9 : class where T10 : class where T11 : class where T12 : class where T13 : class where T14 : class where T15 : class where T16 : class => LocalWithIndex(that, indexName, rule);
    static TReturn LocalWithIndex<TReturn>(TReturn query, string indexName, Dictionary<Type, string> rule)
    {
        if (string.IsNullOrWhiteSpace(indexName)) return query;
        var selectProvider = query as Select0Provider;
        var oldalias = selectProvider._aliasRule;
        selectProvider._aliasRule = (type, old) =>
        {
            if (oldalias != null) old = oldalias(type, old);
            if (type == selectProvider._tables[0].Table.Type) return LocalAppendWithString(old, $"index={indexName}");
            if (rule == null) return old;
            return rule.TryGetValue(type, out var tryidxName) && string.IsNullOrWhiteSpace(tryidxName) == false ? LocalAppendWithString(old, $"index={tryidxName}") : old;
        };
        return query;
    }
    static string LocalAppendWithString(string old, string str) => old?.Contains(" With(") == true ? old.Replace(" With(", $" With({str}, ") : $"{old} With({str})";

    /// <summary>
    /// 设置全局 SqlServer with(nolock) 查询
    /// </summary>
    /// <param name="that"></param>
    /// <param name="options"></param>
    public static IFreeSql SetGlobalSelectWithLock(this IFreeSql that, SqlServerLock lockType, Dictionary<Type, bool> rule)
    {
        var value = NativeTuple.Create(lockType, rule);
        _dicSetGlobalSelectWithLock.AddOrUpdate(that.Ado.Identifier, value, (_, __) => value);
        return that;
    }
    internal static ConcurrentDictionary<Guid, NativeTuple<SqlServerLock, Dictionary<Type, bool>>> _dicSetGlobalSelectWithLock = new ConcurrentDictionary<Guid, NativeTuple<SqlServerLock, Dictionary<Type, bool>>>();

    #region ExecuteSqlBulkCopy
    /// <summary>
    /// SqlServer SqlCopyBulk 批量插入功能<para></para>
    /// 使用 IgnoreColumns/InsertColumns 设置忽略/指定导入的列<para></para>
    /// 使用 WithConnection/WithTransaction 传入连接/事务对象<para></para>
    /// 提示：若本方法不能满足，请使用 IInsert&lt;T&gt;.ToDataTable 方法得到 DataTable 对象后，自行处理。<para></para>
    /// SqlCopyBulk 与 insert into t values(..),(..),(..) 性能测试参考：<para></para>
    /// 插入180000行，52列：21,065ms 与 402,355ms，10列：4,248ms 与 47,204ms<para></para>
    /// 插入10000行，52列：578ms 与 24,847ms，10列：127ms 与 2,275ms<para></para>
    /// 插入5000行，52列：326ms 与 11,465ms，10列：71ms 与 1,108ms<para></para>
    /// 插入2000行，52列：139ms 与 4,971ms，10列：30ms 与 488ms<para></para>
    /// 插入1000行，52列：105ms 与 2,437ms，10列：48ms 与 279ms<para></para>
    /// 插入500行，52列：79ms 与 915ms，10列：14ms 与 123ms<para></para>
    /// 插入100行，52列：60ms 与 138ms，10列：11ms 与 35ms<para></para>
    /// 插入50行，52列：48ms 与 88ms，10列：10ms 与 16ms<para></para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="that"></param>
    /// <param name="copyOptions"></param>
    /// <param name="batchSize"></param>
    /// <param name="bulkCopyTimeout"></param>
    public static void ExecuteSqlBulkCopy<T>(this IInsert<T> that, SqlBulkCopyOptions copyOptions = SqlBulkCopyOptions.Default, int? batchSize = null, int? bulkCopyTimeout = null) where T : class
    {
        var insert = that as FreeSql.SqlServer.Curd.SqlServerInsert<T>;
        if (insert == null) throw new Exception(CoreStrings.S_Features_Unique("ExecuteSqlBulkCopy", "SqlServer"));

        var dt = that.ToDataTable();
        if (dt.Rows.Count == 0) return;

        Action<SqlBulkCopy> writeToServer = bulkCopy =>
        {
            if (batchSize.HasValue) bulkCopy.BatchSize = batchSize.Value;
            if (bulkCopyTimeout.HasValue) bulkCopy.BulkCopyTimeout = bulkCopyTimeout.Value;
            bulkCopy.DestinationTableName = dt.TableName;
            for (int i = 0; i < dt.Columns.Count; i++)
                bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
            bulkCopy.WriteToServer(dt);
        };

        try
        {
            if (insert.InternalConnection == null && insert.InternalTransaction == null)
            {
                if (insert._orm.Ado?.TransactionCurrentThread != null)
                    using (var bulkCopy = new SqlBulkCopy(insert._orm.Ado.TransactionCurrentThread.Connection as SqlConnection, copyOptions, insert._orm.Ado.TransactionCurrentThread as SqlTransaction))
                        writeToServer(bulkCopy);
                else
                    using (var conn = insert.InternalOrm.Ado.MasterPool.Get())
                    {
                        using (var bulkCopy = copyOptions == SqlBulkCopyOptions.Default ?
                            new SqlBulkCopy(conn.Value as SqlConnection) :
                            new SqlBulkCopy(conn.Value as SqlConnection, copyOptions, null))
                        {
                            writeToServer(bulkCopy);
                        }
                    }
            }
            else if (insert.InternalTransaction != null)
            {
                using (var bulkCopy = new SqlBulkCopy(insert.InternalTransaction.Connection as SqlConnection, copyOptions, insert.InternalTransaction as SqlTransaction))
                {
                    writeToServer(bulkCopy);
                }
            }
            else if (insert.InternalConnection != null)
            {
                var conn = insert.InternalConnection as SqlConnection;
                var isNotOpen = false;
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    isNotOpen = true;
                    conn.Open();
                }
                try
                {
                    using (var bulkCopy = copyOptions == SqlBulkCopyOptions.Default ?
                        new SqlBulkCopy(conn) :
                        new SqlBulkCopy(conn, copyOptions, null))
                    {
                        writeToServer(bulkCopy);
                    }
                }
                finally
                {
                    if (isNotOpen)
                        conn.Close();
                }
            }
            else
            {
                throw new NotImplementedException($"ExecuteSqlBulkCopy {CoreStrings.S_Not_Implemented_FeedBack}");
            }
        }
        finally
        {
            dt.Clear();
        }
    }
#if net40
#else
    async public static Task ExecuteSqlBulkCopyAsync<T>(this IInsert<T> that, SqlBulkCopyOptions copyOptions = SqlBulkCopyOptions.Default, int? batchSize = null, int? bulkCopyTimeout = null, CancellationToken cancellationToken = default) where T : class
    {
        var insert = that as FreeSql.SqlServer.Curd.SqlServerInsert<T>;
        if (insert == null) throw new Exception(CoreStrings.S_Features_Unique("ExecuteSqlBulkCopyAsync", "SqlServer"));

        var dt = that.ToDataTable();
        if (dt.Rows.Count == 0) return;

        Func<SqlBulkCopy, Task> writeToServerAsync = bulkCopy =>
        {
            if (batchSize.HasValue) bulkCopy.BatchSize = batchSize.Value;
            if (bulkCopyTimeout.HasValue) bulkCopy.BulkCopyTimeout = bulkCopyTimeout.Value;
            bulkCopy.DestinationTableName = dt.TableName;
            for (int i = 0; i < dt.Columns.Count; i++)
                bulkCopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
            return bulkCopy.WriteToServerAsync(dt, cancellationToken);
        };

        try
        {
            if (insert.InternalConnection == null && insert.InternalTransaction == null)
            {
                if (insert._orm.Ado?.TransactionCurrentThread != null)
                    using (var bulkCopy = new SqlBulkCopy(insert._orm.Ado.TransactionCurrentThread.Connection as SqlConnection, copyOptions, insert._orm.Ado.TransactionCurrentThread as SqlTransaction))
                        await writeToServerAsync(bulkCopy);
                else
                    using (var conn = await insert.InternalOrm.Ado.MasterPool.GetAsync())
                    {
                        using (var bulkCopy = copyOptions == SqlBulkCopyOptions.Default ?
                            new SqlBulkCopy(conn.Value as SqlConnection) :
                            new SqlBulkCopy(conn.Value as SqlConnection, copyOptions, null))
                        {
                            await writeToServerAsync(bulkCopy);
                        }
                    }
            }
            else if (insert.InternalTransaction != null)
            {
                using (var bulkCopy = new SqlBulkCopy(insert.InternalTransaction.Connection as SqlConnection, copyOptions, insert.InternalTransaction as SqlTransaction))
                {
                    await writeToServerAsync(bulkCopy);
                }
            }
            else if (insert.InternalConnection != null)
            {
                var conn = insert.InternalConnection as SqlConnection;
                var isNotOpen = false;
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    isNotOpen = true;
                    await conn.OpenAsync(cancellationToken);
                }
                try
                {
                    using (var bulkCopy = copyOptions == SqlBulkCopyOptions.Default ?
                        new SqlBulkCopy(conn) :
                        new SqlBulkCopy(conn, copyOptions, null))
                    {
                        await writeToServerAsync(bulkCopy);
                    }
                }
                finally
                {
                    if (isNotOpen)
                        conn.Close();
                }
            }
            else
            {
                throw new NotImplementedException($"ExecuteSqlBulkCopyAsync {CoreStrings.S_Not_Implemented_FeedBack}");
            }
        }
        finally
        {
            dt.Clear();
        }
    }
#endif
    #endregion
}

[Flags]
public enum SqlServerLock
{
    NoLock = 1,
    HoldLock = 2,
    UpdLock = 4,
    RowLock = 8,
    ReadCommitted = 16,
    ReadPast = 32,
    ReadUnCommitted = 64,
    RepeaTableRead = 256,
    PagLock = 512,
    Serializable = 1024,
    TabLock = 2048,
    TabLockX = 4096,
    XLock = 8192,
    NoWait = 16384
}