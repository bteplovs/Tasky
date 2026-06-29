import { useEffect, useState } from "react";
import type { ColumnBoard } from "../types/boardTypes";
import Modal from "./Modal";
import TaskCard from "./TaskCard";
import axios from "axios";

interface ColumnProps {
    column: ColumnBoard;
}

const Column = ({ column }: ColumnProps) => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const id = column.id;

    const [columnName, setColumnName] = useState("");

    // Errors
    // interface IColumnNameError {errorMessage: string; hasError: boolean; }
    // const [columnNameError, setColumnNameError] = useState<IColumnNameError>({errorMessage: "", hasError: false});

    // function validateInputs(boardName: string) {
    //     setColumnNameError({errorMessage: "", hasError: false})
    //     if (boardName.trim().length == 0) {
    //         setColumnNameError({errorMessage: "Name cannot be empty", hasError: true})
    //         return false
    //     }

    //     setColumnNameError({errorMessage: "", hasError: false})
    //     return true;
        
    // }

    // const createTask = async () => {
    //     const isValid = validateInputs(columnName)
    //     if (!isValid) {
    //         return;
    //     }

    //     try {
    //         const res = await axios.post(`http://localhost:5267/api/columns/${id}/tasks`, {title, description})
    //         setColumnName("");
    //         setColumnNameError({
    //             errorMessage: "",
    //             hasError: false
    //         });
    //         setIsModalOpen(false);
    //     } catch (error) {
    //         console.log(error)
    //     }
    // }

    // useEffect(() => {
        
    // }, [])

    return (
        <div className="flex max-h-full w-80 shrink-0 flex-col rounded-lg p-4 border-2 border-blue-400">
            <div className="flex justify-between p-2">
                <div className="flex justify-center items-center">
                    <h1>{column.name}</h1>
                </div>
                <button
                    onClick={() => console.log("hello")}
                    className="text-left rounded-xl flex h-full justify-center items-center px-2 gap-1 hover:bg-blue-400 active:translate-y-0.5 active:shadow-lg hover:text-white transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">+</p>
                </button>
                <Modal isOpen={isModalOpen} OnClose={() => setIsModalOpen(false)}>
                    <div className="flex flex-col gap-4 font-mono">
                        <h1 className="text-lg">Create Column</h1>
                        <div className="flex flex-col gap-2 pl-2 pr-2">
                            <p className="text-md">Column Name</p>
                            <input
                                type="text"
                                value={columnName}
                                onChange={(e) => setColumnName(e.target.value)}
                                className="border border-blue-500 rounded-xl p-3"
                            >
                            </input>
                            {/* {columnNameError.hasError && 
                                <p className="text-sm text-red-400">{columnNameError.errorMessage}</p>
                            } */}
                            <div className="flex justify-between pt-4">
                                <button 
                                className="p-2 cursor-pointer bg-red-400 hover:bg-red-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => setIsModalOpen(false)}
                                >
                                    Cancel
                                </button>
                                <button 
                                className="p-2 cursor-pointer bg-blue-400 hover:bg-blue-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => console.log("hello")}
                                >
                                    Create
                                </button>
                            </div>
                        </div>
                    </div>
                </Modal>
            </div>
            <div className="flex flex-col gap-2">
                {column.tasks.map((item) => (
                    <TaskCard key={item.id} task={item} />
                ))}
            </div>
        </div>
    );
}

export default Column