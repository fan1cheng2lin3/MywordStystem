<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

public int GetWordcoust(int userId)
{
    var today = DateTime.UtcNow.Date;
    int wordCount = 0;
    try
    {
        wordCount = db.progress
                      .Where(wp => wp.UserId == userId)
                      .AsEnumerable() // 使用 AsEnumerable 以允许多次枚举
                      .Where(p => !string.IsNullOrEmpty(p.lasttime))
                      .Select(p =>
                      {
                          try
                          {
                              return DateTime.Parse(p.lasttime).Date != today;
                          }
                          catch (FormatException)
                          {
                              return false; // 或者根据你的需求处理错误
                          }
                      })
                      .Count();
    }
    catch (Exception ex)
    {
        // 记录异常信息，例如使用日志记录
        Console.WriteLine("Error getting word count: " + ex.Message);
        // 可能需要返回一个错误码或者特殊值来表示失败
    }
    return wordCount;
}