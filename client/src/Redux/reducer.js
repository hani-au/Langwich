const userState = {    
    user:{}

}
export default function reducer(state = userState, action) {
    debugger
    switch (action.type) {
        case 'SET_USER':
            debugger
            state.user = action.payload;
            state = { ...state }
            break;

        default:
            debugger
            return state;
    }
    return state
}

