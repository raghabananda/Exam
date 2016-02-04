using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Question
/// </summary>
public class Question:Subject
{
     public string QuestionID{get;set;}
     public string SubjectName{get;set;}
     public string question{get;set;}
     public string A{get;set;}
     public string B{get;set;}
     public string C{get;set;}
     public string D{get;set;}
     public string Answer{get;set;}
    public Question()
    {
        
    }
    public IEnumerable<Question> QuestionListBySubject()
    {
        Database Db=Database.Open("ExamSystem");
        string Command="SELECT [QuestionID], [Question], [A], [B], [C], [D], [Answer] FROM [Question] Where [SubjectID]=@0";
        IEnumerable<dynamic> Data=Db.Query(Command,this.ID); 
        List<Question> QuestionList=new List<Question>();
        foreach(var item in Data)       
        {
            Question TheQuestion=new Question(){
                QuestionID=item.QuestionID.ToString(),
                question=item.Question,
                A=item.A,
                B=item.B,
                C=item.C,
                D=item.D,
                Answer=item.Answer
            };  
           QuestionList.Add(TheQuestion);     
        }       
                         
        return QuestionList;
    } 
    public IEnumerable<Question> AllQuestionID()
    {
        Database Db=Database.Open("ExamSystem");
        string Command="SELECT [QuestionID] FROM [Question]";
        IEnumerable<dynamic> Data=Db.Query(Command); 
        List<Question> QuestionList=new List<Question>();
        foreach(var item in Data)       
        {
            Question TheQuestion=new Question(){
                QuestionID=item.QuestionID.ToString()               
            };  
           QuestionList.Add(TheQuestion);     
        }                                
        return QuestionList;
    }
}
