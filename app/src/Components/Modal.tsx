import { type ReactNode } from "react";
import { createPortal } from "react-dom";

interface ModalProps {
    isOpen: boolean;
    OnClose: () => void;
    children: ReactNode
}

const Modal = ({ isOpen, OnClose, children} : ModalProps) => {
    if (!isOpen) return null;

    return createPortal(
        <div className="fixed inset-0 bg-black/60 z-40 backdrop-blur-sm" onClick={OnClose}>
            <div className="transition-all duration- fixed left-1/2 top-1/2 z-50 w-[88%] max-w-2xl -translate-x-1/2 -translate-y-1/2 flex flex-col gap-2 rounded-xl bg-white p-5 shadow-2xl" onClick={(e)=>e.stopPropagation()}>
                {children}
            </div>
        </div>,
        document.body
    );
}


export default Modal