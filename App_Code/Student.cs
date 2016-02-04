using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;


public class Student
{
    //Properties
   public int StudentID{get;set;}
   public string FirstName{get;set;}
   public string LastName{get;set;}
   public string Gender{get;set;}
   public string Email{get;set;}
   public string PassWord{get;set;}

   //Methods
  
   bool EmailCheck()
   {
       Database Db=Database.Open("ExamSystem");
       string CheckCommnd = "SELECT COUNT(*) FROM [Student] WHERE [Email] = @0";
       dynamic dyn = Db.QueryValue(CheckCommnd,this.Email);
       int? i= dyn as int?;
       return i>0;
   }
   public bool InsertData()
   {      
       if(!EmailCheck())
       {
            Database Db=Database.Open("ExamSystem");
            string InsertCommand="INSERT INTO Student (FirstName, LastName, Gender, Email, PassWord)  VALUES  (@0,@1,@2,@3,@4);";
            Db.Execute(InsertCommand,this.FirstName,this.LastName,this.Gender,this.Email,this.PassWord);           
            return true;
       }
       else{
           return false;
       }
      
   }
   public bool StudentLogIn()
   {
       if(EmailCheck())
       {
           Database Db=Database.Open("ExamSystem");
           string SelectCommand="SELECT [StudentID], [FirstName], [LastName], [Gender], [Email], [PassWord] FROM [Student] WHERE [Email] = @0" ;
           dynamic LogInData=Db.QuerySingle(SelectCommand,this.Email);
          if(this.Email.Equals(LogInData.Email) &&
           this.PassWord.Equals(LogInData.PassWord))
           {
               this.FirstName=LogInData.FirstName;
               this.StudentID=LogInData.StudentID;
             return true;  
           }else{
               return false;
           }
       }else{
           return false;
       }
        
   }
   public string StudentNameByID()
   {
      string SelectCommand="SELECT [FirstName] FROM [Student] WHERE [StudentID] = @0" ; 
      Database Db=Database.Open("ExamSystem");
      dynamic dyn=Db.QuerySingle(SelectCommand,this.StudentID);
      if(dyn!=null)
      {
          return dyn.FirstName;
      }else{
         return null;
      }
   }
    
   public void DeleteStudentID()
   {
       string DeleteCommand="DELETE FROM [Student] WHERE [StudentID] = @0" ;
       Database Db=Database.Open("ExamSystem");
       Db.Execute(DeleteCommand,this.StudentID);
   }
}
