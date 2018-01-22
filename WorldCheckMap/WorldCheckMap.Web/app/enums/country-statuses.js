const statuses = {
    none: {
        name: 'None',
        code: 0
    },
    wish: {
        name: 'Wish',
        code: 1
    },
    been: {
        name: 'Been',
        code: 2
    },
    lived: {
        name: 'Lived',
        code: 3
    }
};

export function getStatusByCode(code) {
    const foundEntry = Object.entries(statuses).find(e => e[1].code === code);
    return foundEntry[1];
}

export default statuses;