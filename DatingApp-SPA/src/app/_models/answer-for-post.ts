import { Injectable } from '@angular/core';
@Injectable({
    providedIn: 'root'
  })

export class AnswerForPost {
    QuestionId:number;
    Solution:string;
    UserId:number;
}