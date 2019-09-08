import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Question } from 'src/app/_models/question';
import { QuestionService } from 'src/app/_services/question.service';
import { QuestionForList } from 'src/app/_models/question-for-list';

@Component({
  selector: 'app-post-question',
  templateUrl: './post-question.component.html',
  styleUrls: ['./post-question.component.css']
})
export class PostQuestionComponent implements OnInit {

  question:Question;
  postQuestionTag:any;
  dropdownSettings: any = {};
  @Output() questionForList = new EventEmitter();

  constructor(private alertify:AlertifyService,
    private _question:Question,private questionservice:QuestionService) {
    this.question = this._question;
   }

  ngOnInit() {
    
  }
  PostQuestion(){
    this.questionservice.PostQuestion(this.question).subscribe(next => {
      this.questionForList.emit(next);
      debugger;
      this.alertify.success('Query posted successfully')
    }, error => {
      this.alertify.error(error)
    },()=>{
      // this.router.navigate(['/members']);
    })
  }
}
