import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { QuestionToPost } from '../_models/question-to-post';
import { QuestionForList } from '../_models/question-for-list';
import { Question } from '../_models/question';
import { QuestionForDetail } from '../_models/question-for-detail';
import { AnswerForPost } from '../_models/answer-for-post';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  


baseUrl = environment.apiUrl + 'question/';
  constructor(private http: HttpClient) { }

  PostQuestion(question:QuestionToPost)
  {
    return this.http.post(this.baseUrl, question);
  }
  GetQuestions() {
    return this.http.get<QuestionForList[]>(this.baseUrl);
  }
  GetQuestionById(id){
    return this.http.get<QuestionForDetail>(this.baseUrl+id);
  }
  PostAnswer(answer: AnswerForPost) {
    debugger;
    return this.http.post(this.baseUrl+"answer/", answer);
  }

}