import { Injectable } from '@angular/core';
@Injectable({
    providedIn: 'root'
  })

export class AnswerForPost {
    QuestionId:string;
    Solution:string;
}