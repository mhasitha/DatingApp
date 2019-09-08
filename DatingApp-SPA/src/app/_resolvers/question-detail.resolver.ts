import { Injectable } from "@angular/core";
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { QuestionService } from '../_services/question.service';
import { QuestionForDetail } from '../_models/question-for-detail';

@Injectable()
export class QuestionDetailResolver implements Resolve<QuestionForDetail>{
    /**
     *
     */
    constructor(private questionService: QuestionService, private router: Router, private alertify: AlertifyService) {

    }
    resolve(route: ActivatedRouteSnapshot): Observable<QuestionForDetail> {
        return this.questionService.GetQuestionById(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error("Problem retriving data");
                this.router.navigate(['/home']);
                return of(null);
            })
        )
    }

}