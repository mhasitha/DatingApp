import { Tag } from './tag';

export interface QuestionForList {
    id:number;
    heading:string;
    userId:string; 
    description:string;
    createdDate:Date;
    resolved:boolean;
}