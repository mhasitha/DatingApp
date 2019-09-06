import { Tag } from './tag';

export interface QuestionForList {
    id:string;
    heading:string;
    tags:Tag[];
    userId:string; 
    description:string;
    createdDate:Date;
    resolved:boolean;
}