import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { QuestionToPost } from '../_models/question-to-post';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {


baseUrl = environment.apiUrl + 'question/';
  constructor(private http: HttpClient) { }


AddQuestion(question:QuestionToPost)
{
  return this.http.post(this.baseUrl, question);
}







}