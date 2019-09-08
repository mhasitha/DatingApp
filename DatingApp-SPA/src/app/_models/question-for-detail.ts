import { Tag } from './tag';
import { Answer } from './answer';

export interface QuestionForDetail {
    id:number;
    heading:string;
    answers:Answer[];
    userId:number; 
    description:string;
    createdDate:Date;
    resolved:boolean;
}