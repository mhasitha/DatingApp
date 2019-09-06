import { Component, OnInit } from '@angular/core';
import { QuestionToPost } from 'src/app/_models/question-to-post';
import { QuestionService } from 'src/app/_services/question.service';

@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.css']
})
export class QuestionListComponent implements OnInit {

  question:QuestionToPost;
  questionSevice:QuestionService
  constructor(_questionSevice:QuestionService) {
    this.question = new QuestionToPost();
    this.questionSevice = _questionSevice;
   }

  ngOnInit() {
  }
  postQuestion(){

    this.questionSevice.AddQuestion(this.question).subscribe(next => {
      
      // this.alertify.success('Posted successfully')
    }, error => {
      // this.alertify.error("error")
    },()=>{
      // this.router.navigate(['/members']);
    })
    // this.questionSevice.AddQuestion(this.question);
  }
}
