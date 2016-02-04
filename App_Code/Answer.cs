using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Answer
/// </summary>
public class Answer:Student
{
  //properties
  public int AnswerID{get;set;} 
  public int QuestionID{get;set;}
  public String AnsOption{get;set;}

  //Methods
  public Answer[] BringAnswer()
  {
     string SelectCommand="SELECT [QuestionID], [Answer] FROM [StudentExam] WHERE [StudentID]=@0";
     Database Db=Database.Open("ExamSystem");
     IEnumerable<dynamic> Data=Db.Query(SelectCommand,this.StudentID);
     List<Answer> AnswerList=new List<Answer>();
     foreach(var item in Data)
     {
         Answer answer=new Answer(){
             QuestionID=item.QuestionID,
             AnsOption=item.Answer
         };
         AnswerList.Add(answer);
     }
     return AnswerList.ToArray();         
  }

  public int[] QIDArr(Answer[] Ansarr)
  {
      int[] QID=new int[Ansarr.Length];
      for(int i=0;i<Ansarr.Length;i++)
      {
          QID[i]=Ansarr[i].QuestionID;
      }
      return QID;
  }
  public string[] Ansarray(Answer[] Ans)
  {
      string[] Ansarr=new string[Ans.Length];
      for(int i=0;i<Ans.Length;i++)
      {
          Ansarr[i]=Ans[i].AnsOption;
      }
      return Ansarr;
  }
  public void AnswerSubmit()
  {
      string InsertCommand="INSERT INTO [StudentExam] ([StudentID], [QuestionID], [Answer]) VALUES (@0, @1, @2)" ;
      Database Db=Database.Open("ExamSystem");
      Db.Execute(InsertCommand,this.StudentID,this.QuestionID,this.AnsOption);
  }

  public Answer[] BringOriginalAnswer()
  {
      List<Answer> QuestionList=new List<Answer>();
      string SelectCommand="SELECT [QuestionID], [Answer] FROM [Question]" ;
      Database Db=Database.Open("ExamSystem");
      IEnumerable<dynamic> Datas=Db.Query(SelectCommand);
      foreach(var item in Datas)
      {
          Answer A=new Answer(){
              QuestionID=item.QuestionID,
              AnsOption=item.Answer
          };
          QuestionList.Add(A);
      }
      return QuestionList.ToArray();
  }

  public override bool Equals(object Ans)
  {
      Answer a=(Answer)Ans;
      return a.QuestionID.Equals(this.QuestionID) && a.AnsOption.Equals(this.AnsOption);
  }
}
