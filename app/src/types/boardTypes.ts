
export type BoardCardData = {
    id: number;
    name: string;
    numTasks: number;
}

export type Board = {
    id: number;
    name: string;
    columns: ColumnBoard[]
}

export type ColumnBoard = {
    id: number;
    name: string; 
    tasks: TaskBoard[];
}

export type TaskBoard = {
    id: number;
    title: string;
}