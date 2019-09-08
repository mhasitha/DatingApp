import { Component, OnInit } from '@angular/core';
import { QuestionToPost } from 'src/app/_models/question-to-post';
import { QuestionService } from 'src/app/_services/question.service';
import { QuestionForList } from 'src/app/_models/question-for-list';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  question:QuestionToPost;
  questionList:QuestionForList[];
  newListObj:QuestionForList;
  constructor(private questionSevice:QuestionService,private alertify:AlertifyService) {
    this.question = new QuestionToPost();
   }

  ngOnInit() {
    this.questionSevice.GetQuestions().subscribe(response => { this.questionList = response;
      debugger;
    }
      , error => { this.alertify.error("Error occured while retriving Questions !!!") });
  }
  postQuestion(){

    this.questionSevice.PostQuestion(this.question).subscribe(next => {
      
      // this.alertify.success('Posted successfully')
    }, error => {
      // this.alertify.error("error")
    },()=>{
      // this.router.navigate(['/members']);
    })
    // this.questionSevice.AddQuestion(this.question);
  }
  addToList(e){
    this.newListObj = null;
    this.newListObj = e;
    this.questionList.push(this.newListObj);
    console.log(e);
    debugger;
  }
}
