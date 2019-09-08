import { Component, OnInit, Input } from '@angular/core';
import { AnswerForPost } from 'src/app/_models/answer-for-post';
import { AuthService } from 'src/app/_services/auth.service';
import { QuestionService } from 'src/app/_services/question.service';
import { AlertifyService } from 'src/app/_services/alertify.service';

@Component({
  selector: 'app-post-answer',
  templateUrl: './post-answer.component.html',
  styleUrls: ['./post-answer.component.css']
})
export class PostAnswerComponent implements OnInit {

  @Input() QuestionId: number;
  userid:number;
  answerForPost:AnswerForPost;
  constructor(_answerForPost:AnswerForPost,private authService:AuthService
    ,private alertify:AlertifyService,private questionService:QuestionService) { 
    this.answerForPost=_answerForPost;
  }

  ngOnInit() {
    this.answerForPost.QuestionId=this.QuestionId;
  }

  PostAnswer(){
    this.userid=this.authService.decodedToken.nameid;
    if(this.userid== undefined)
    {
      this.alertify.error("Please Login to Post Your Answer.");
    }else{
      this.answerForPost.UserId = this.userid;
      this.questionService.PostAnswer(this.answerForPost).subscribe(next => {
      
        this.alertify.success('Posted successfully')
      }, error => {
        this.alertify.error("error")
      },()=>{
        // this.router.navigate(['/members']);
      })
      // alert(this.authService.decodedToken.nameid)
    }
  }
}
