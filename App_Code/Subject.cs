using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public int ID{get;set;}
    public string SubjectName{get;set;}
   
    public static Subject[] SubjectID()
    {
        Database Db= Database.Open("ExamSystem");
        string Command="SELECT DISTINCT Subject.ID,Subject.SubjectName As SubjectName FROM Question INNER JOIN Subject ON Question.SubjectID = Subject.ID ";       
        List<Subject> Data= new List<Subject>();
       
        IEnumerable<dynamic> data=Db.Query(Command);
        foreach (var item in data)
        {
            Subject q= new Subject();
            q.ID=item.ID;
            q.SubjectName=item.SubjectName;
            Data.Add(q);
        }
       return Data.ToArray();
    }
}
