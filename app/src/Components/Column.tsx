import { useEffect, useState } from "react";
import type { ColumnBoard } from "../types/boardTypes";
import Modal from "./Modal";
import TaskCard from "./TaskCard";
import axios from "axios";

interface ColumnProps {
    column: ColumnBoard;
    onTaskCreated: () => void;
}

const Column = ({ column, onTaskCreated }: ColumnProps) => {
    const [isModalOpen, setIsModalOpen] = useState(false);
    const id = column.id;

    const [taskName, setTaskName] = useState("");

    interface ITaskNameError {errorMessage: string; hasError: boolean; }
    const [taskNameError, setTaskNameError] = useState<ITaskNameError>({errorMessage: "", hasError: false});

    function validateInputs(boardName: string) {
        setTaskNameError({errorMessage: "", hasError: false})
        if (boardName.trim().length == 0) {
            setTaskNameError({errorMessage: "Name cannot be empty", hasError: true})
            return false
        }

        setTaskNameError({errorMessage: "", hasError: false})
        return true;
        
    }

    const createTask = async () => {
        const isValid = validateInputs(taskName)
        if (!isValid) {
            return;
        }

        try {
            const res = await axios.post(`http://localhost:5267/api/columns/${id}/tasks`, {title: taskName, description: ""}) //update this later
            await onTaskCreated();
            setTaskName("");
            setTaskNameError({
                errorMessage: "",
                hasError: false
            });
            setIsModalOpen(false);
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <div className="flex max-h-full w-80 shrink-0 flex-col rounded-lg p-4 border-2 border-blue-400">
            <div className="flex justify-between p-2">
                <div className="flex justify-center items-center">
                    <h1>{column.name}</h1>
                </div>
                <button
                    onClick={() => setIsModalOpen(true)}
                    className="text-left rounded-xl flex h-full justify-center items-center px-2 gap-1 hover:bg-blue-400 active:translate-y-0.5 active:shadow-lg hover:text-white transition-all font-mono select-none cursor-pointer"
                >
                    <p className="text-lg font-bold">+</p>
                </button>
                <Modal isOpen={isModalOpen} OnClose={() => setIsModalOpen(false)}>
                    <div className="flex flex-col gap-4 font-mono">
                        <h1 className="text-lg">New task</h1>
                        <div className="flex flex-col gap-2 pl-2 pr-2">
                            <p className="text-md">Task Name</p>
                            <input
                                type="text"
                                value={taskName}
                                onChange={(e) => setTaskName(e.target.value)}
                                className="border border-blue-500 rounded-xl p-3"
                            >
                            </input>
                            {taskNameError.hasError && 
                                <p className="text-sm text-red-400">{taskNameError.errorMessage}</p>
                            }
                            <div className="flex justify-between pt-4">
                                <button 
                                className="p-2 cursor-pointer bg-red-400 hover:bg-red-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => setIsModalOpen(false)}
                                >
                                    Cancel
                                </button>
                                <button 
                                className="p-2 cursor-pointer bg-blue-400 hover:bg-blue-300 rounded-xl active:translate-y-0.5 active:shadow-lg"
                                onClick={() => createTask()}
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