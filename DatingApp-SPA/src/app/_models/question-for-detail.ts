import { Tag } from './tag';
import { Answer } from './answer';

export interface QuestionForDetail {
    id:string;
    heading:string;
    answers:Answer;
    tags:Tag[];
    userId:string; 
    description:string;
    createdDate:Date;
    resolved:boolean;
}