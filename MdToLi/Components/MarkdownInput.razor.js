export function getSelection(textarea) {
    return {
        start: textarea.selectionStart,
        end: textarea.selectionEnd
    };
}

export function setSelection(textarea, start, end) {
    textarea.focus();
    textarea.setSelectionRange(start, end);
}
